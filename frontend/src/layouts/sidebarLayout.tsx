import { Button, buttonVariants } from "@/components/ui/button";
import { useAuth } from "@/context";
import { CarIcon, HomeIcon, LogOutIcon, TicketIcon } from "lucide-react";
import { type ReactElement } from "react";
import { Outlet, NavLink, NavLinkProps } from "react-router-dom";

const linkClasses: NavLinkProps["className"] = ({ isActive }) =>
  buttonVariants({
    className: "justify-start gap-x-4",
    variant: isActive ? "default" : "ghost",
  });

export function SidebarLayout(): ReactElement {
  const { logout } = useAuth();

  return (
    <div className="flex flex-row min-h-screen">
      <aside className="w-80 border-r flex flex-col">
        <h1 className="p-8 text-center font-bold text-3xl">MobiPark</h1>

        <nav className="flex flex-col gap-y-2 p-4">
          <NavLink className={linkClasses} to="/">
            <HomeIcon className="size-5" />
            Réserver
          </NavLink>
          <NavLink className={linkClasses} to="/my-reservations">
            <TicketIcon className="size-5" />
            Mes réservations
          </NavLink>
          <NavLink className={linkClasses} to="/my-vehicles">
            <CarIcon className="size-5" />
            Mes véhicules
          </NavLink>
        </nav>
      </aside>

      <div className="flex-1">
        <header className="flex flex-row justify-end items-center px-8 py-4">
          <Button variant="ghost" className="gap-x-2" onClick={() => logout()}>
            <LogOutIcon className="size-5" />
            Logout
          </Button>
        </header>
        <main className="p-4 md:px-16">
          <Outlet />
        </main>
      </div>
    </div>
  );
}
