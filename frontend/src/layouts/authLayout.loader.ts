import { fetchUser } from "@/api/user";
import { QueryClient } from "@tanstack/react-query";
import { LoaderFunction } from "react-router-dom";

export function authLoader(
  queryClient: QueryClient,
  callback: (connected: boolean) => void
): LoaderFunction<void> {
  return async () => {
    try {
      const value = await queryClient.fetchQuery({
        queryKey: ["auth", "user"],
        queryFn: fetchUser,
      });

      return callback(Boolean(value));
    } catch (error) {
      return callback(false);
    }
  };
}
