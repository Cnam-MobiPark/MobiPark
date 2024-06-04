import React, { useEffect, useState } from 'react';
import { type ReactElement } from "react";
import { PageHeader } from "../../components/page_header";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";

interface Reservation {
  vehicle: string;
  place: string;
  beginDate: string;
  endDate: string;
}

export function MyReservations(): ReactElement {
  const [reservations, setReservations] = useState<Reservation[]>([]);

  useEffect(() => {
    const fetchReservations = async () => {
      try {
        const response = await fetch('/reservations.json');
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const data: Reservation[] = await response.json();
        setReservations(data);
      } catch (error) {
        console.error('Failed to fetch reservations:', error);
      }
    };

    fetchReservations();
  }, []);

  return (
    <div>
      <PageHeader
        title="Mes réservations"
        description="Consulter vos places réservées pour vos véhicules"
      />
      <div className="overflow-x-auto mb-8">
        <Table className="min-w-full bg-white border border-gray-300">
          <TableHeader>
            <TableRow>
              <TableHead className="py-2 px-4 border-b border-gray-300 text-left">Véhicule</TableHead>
              <TableHead className="py-2 px-4 border-b border-gray-300 text-left">Place</TableHead>
              <TableHead className="py-2 px-4 border-b border-gray-300 text-left">Date début</TableHead>
              <TableHead className="py-2 px-4 border-b border-gray-300 text-left">Date fin</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {reservations.map((reservation, index) => (
              <TableRow key={index}>
                <TableCell className="py-2 px-4 border-b border-gray-300">{reservation.vehicle}</TableCell>
                <TableCell className="py-2 px-4 border-b border-gray-300">{reservation.place}</TableCell>
                <TableCell className="py-2 px-4 border-b border-gray-300">{reservation.beginDate}</TableCell>
                <TableCell className="py-2 px-4 border-b border-gray-300">{reservation.endDate}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
    </div>
  );
}
