import { type ReactElement } from "react";
import { PageHeader } from "../../components/page_header";
import { Table } from "@/components/ui/table";

const reservations = [
  {
    vehicle: "Renault Scenic",
    place: "18B",
    beginDate: "22/05/2024 à 15:45",
    endDate: "22/05/2024 à 17:00",
  },
  {
    vehicle: "Renault Zoé",
    place: "18B",
    beginDate: "25/05/2024 à 15:45",
    endDate: "25/05/2024 à 17:00",
  },
];

export function MyReservations(): ReactElement {
  return (
    <div>
      <PageHeader
        title="Mes réservations"
        description="Consulter vos places réservées pour vos véhicules"
      />
      <div className="overflow-x-auto mb-8">
        <table className="min-w-full bg-white border border-gray-300">
          <thead>
            <tr>
              <th className="py-2 px-4 border-b border-gray-300 text-left">Véhicule</th>
              <th className="py-2 px-4 border-b border-gray-300 text-left">Place</th>
              <th className="py-2 px-4 border-b border-gray-300 text-left">Date début</th>
              <th className="py-2 px-4 border-b border-gray-300 text-left">Date fin</th>
            </tr>
          </thead>
          <tbody>
            {reservations.map((reservation, index) => (
              <tr key={index}>
                <td className="py-2 px-4 border-b border-gray-300">{reservation.vehicle}</td>
                <td className="py-2 px-4 border-b border-gray-300">{reservation.place}</td>
                <td className="py-2 px-4 border-b border-gray-300">{reservation.beginDate}</td>
                <td className="py-2 px-4 border-b border-gray-300">{reservation.endDate}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
