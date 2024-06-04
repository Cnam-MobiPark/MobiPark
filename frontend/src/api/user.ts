import { fetcher, fetcherBody } from "./api";
import { User } from "./types";

export interface LoginRequest {
  username: string;
  password: string;
}

export const loginUser = (data: LoginRequest) =>
  fetcher("/api/Auth", {
    method: "POST",
    body: JSON.stringify(data),
  });

export interface RegisterRequest {
  username: string;
  password: string;
}

export type RegisterResponse = User;

export const registerUser = (data: RegisterRequest) =>
  fetcher("/api/Auth/register", {
    method: "POST",
    body: JSON.stringify(data),
  });

export const fetchUser = () => fetcherBody<User>("/api/Auth");
