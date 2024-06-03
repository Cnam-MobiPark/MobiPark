import { type ReactElement } from "react";
import { PageHeader } from "../../components/page_header";

export function MyReservations(): ReactElement {
  return (
    <div>
      <PageHeader
        title="Mes réservations"
        description="Consulter vos places réservées pour vos véhicules"
      />
    </div>
  );
}
