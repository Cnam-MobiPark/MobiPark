import { useAuth } from "@/context";
import { QueryClient } from "@tanstack/react-query";

export const queryClient = new QueryClient();

export class HttpError extends Error {
  public readonly status: number;

  public constructor(message: string, status: number) {
    super(message);
    this.status = status;
  }
}

interface ValidationError {
  field: string;
  message: string;
  rule: string;
}
export class UnprocessableContentError extends HttpError {
  public constructor(public readonly errors: ValidationError[]) {
    super("Unprocessable content", 422);
  }
}

export class ForbiddenError extends HttpError {
  public constructor(message: string) {
    super(message, 403);
  }
}
export class UnauthorizedError extends HttpError {
  public constructor(message: string) {
    super(message, 402);
  }
}

export class ConflictError extends HttpError {
  public constructor(message: string) {
    super(message, 409);
  }
}

export async function fetcherBody<T>(
  url: string,
  options?: RequestInit
): Promise<T> {
  return fetcher(url, { ...options }).then((res) => res.json());
}

export let jwtToken: string | undefined = undefined;
export const setJwtToken = (token: string | undefined) => {
  jwtToken = token;
};

export async function fetcher(
  url: string,
  options?: RequestInit
): Promise<Response> {
  if (jwtToken) {
    if (!options) {
      options = {};
    }
    if (!options.headers) {
      options.headers = {};
    }
    // @ts-expect-error
    options.headers["Authorization"] = `Bearer ${jwtToken}`;
  }
  const res = await fetch(url, {
    headers: {
      "Content-Type": "application/json",
      ...options?.headers,
    },
    ...options,
  });
  if (!res.ok) {
    if (res.status === 422) {
      throw new UnprocessableContentError(
        await res.json().then((e) => e.errors)
      );
    }

    if (res.status === 409) {
      throw new ConflictError(await res.json().then((e) => e.message));
    }

    if (res.status === 402) {
      throw new UnauthorizedError(await res.json().then((e) => e.message));
    }

    if (res.status === 403) {
      throw new ForbiddenError(await res.json().then((e) => e.message));
    }

    throw new HttpError(
      "An error occurred while fetching the data.",
      res.status
    );
  }

  return res;
}
