import { PageHeader } from "@/components/page_header";
import { type ReactElement } from "react";

export function MyVehicles(): ReactElement {
  return (
    <div>
      <PageHeader
        title="Mes véhicules"
        description="Gérer vos véhicules utilisés pour les réservations"
      />
    </div>
  );
}
