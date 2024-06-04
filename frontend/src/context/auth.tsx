import { setJwtToken } from "@/api/api";
import { loginUser, registerUser } from "@/api/user";
import React, { PropsWithChildren, useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";

export interface AuthContextData {
  token: string | undefined;
  login: (username: string, password: string) => Promise<void>;
  logout: () => void;
  register: (username: string, password: string) => Promise<void>;
}

export const AuthContext = React.createContext<AuthContextData | undefined>(
  undefined
);

export function AuthProvider({ children }: PropsWithChildren<object>) {
  const [token, setToken] = React.useState<string | undefined>(undefined);
  const router = useNavigate();
  const location = useLocation();

  useEffect(() => {
    if (
      token === undefined &&
      !["/login", "/register"].includes(location.pathname)
    ) {
      router("/login");
    }

    setJwtToken(token);
  }, [token]);

  const login = async (username: string, password: string) => {
    const response = await loginUser({ username, password });

    const authorization = response.headers.get("Authorization");
    if (authorization) {
      setToken(authorization);
      router("/");
    }
  };

  const register = async (username: string, password: string) => {
    const response = await registerUser({ username, password });
    const authorization = response.headers.get("Authorization");
    if (authorization) {
      setToken(authorization);
      router("/");
    }
  };

  const logout = () => {
    setToken(undefined);
  };

  const values: AuthContextData = {
    token,
    login,
    logout,
    register,
  };

  return <AuthContext.Provider value={values}>{children}</AuthContext.Provider>;
}
