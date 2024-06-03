import { createBrowserRouter } from "react-router-dom";
import { SidebarLayout } from "./layouts/sidebarLayout";
import { Login } from "./pages/login";
import { UserHome } from "./pages/user/home";
import { MyReservations } from "./pages/user/reservations";
import { MyVehicles } from "./pages/user/vehicles";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <SidebarLayout />,
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
  },
]);
