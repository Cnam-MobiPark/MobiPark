import { Outlet, createBrowserRouter, redirect } from "react-router-dom";
import { SidebarLayout } from "./layouts/sidebarLayout";
import { Login } from "./pages/login";
import { UserHome } from "./pages/user/home";
import { MyReservations } from "./pages/user/reservations";
import { MyVehicles } from "./pages/user/vehicles";
import { authLoader } from "./layouts/authLayout.loader";
import { queryClient } from "./api/api";
import { AuthProvider } from "./context/auth";
import { Register } from "./pages/register";

export const router = createBrowserRouter([
  {
    path: "",
    element: (
      <AuthProvider>
        <Outlet />
      </AuthProvider>
    ),
    children: [
      {
        path: "/",
        errorElement: <div>Not Found</div>,
        element: <SidebarLayout />,
        loader: authLoader(queryClient, (connected) => {
          if (!connected) return redirect("/login");
          return true;
        }),
        children: [
          {
            path: "/",
            element: <UserHome />,
          },
          {
            path: "/my-reservations",
            element: <MyReservations />,
          },
          {
            path: "/my-vehicles",
            element: <MyVehicles />,
          },
        ],
      },
      {
        path: "/login",
        element: <Login />,
        loader: authLoader(queryClient, (connected) => {
          if (connected) return redirect("/");
          return true;
        }),
      },
      {
        path: "/register",
        element: <Register />,
        loader: authLoader(queryClient, (connected) => {
          if (connected) return redirect("/");
          return true;
        }),
      },
    ],
  },
]);
