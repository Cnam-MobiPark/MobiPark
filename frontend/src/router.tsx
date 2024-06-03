import { createBrowserRouter } from "react-router-dom";
import { Login } from "./pages/login";

export const router = createBrowserRouter([
  {
    path: "/",
    children: [
      {
        path: "/",
        element: <h1>Home</h1>,
      },
      {
        path: "/my-reservations",
        element: <h1>Reservations</h1>,
      },
      {
        path: "/my-vehicles",
        element: <h1>Vehicles</h1>,
      },
    ],
  },
  {
    path: "/login",
    element: <Login />,
  },
]);
