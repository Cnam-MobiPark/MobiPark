import { type ReactElement } from "react";
import { PageHeader } from "../../components/page_header";

export function UserHome(): ReactElement {
  return (
    <div>
      <PageHeader
        title="Faire une réservation"
        description="Réserver une place de parking pour votre véhicule"
      />
    </div>
  );
}
