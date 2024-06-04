import React, { useEffect, useState } from "react";
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
import { fetchReservation } from "@/api/reservation";
import { useQuery } from "@tanstack/react-query";

export function MyReservations(): ReactElement {
  const {
    isPending,
    data: reservations,
    error,
  } = useQuery({
    queryKey: ["reservations", "list"],
    queryFn: () => fetchReservation(),
  });

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
              <TableHead className="py-2 px-4 border-b border-gray-300 text-left">
                Véhicule
              </TableHead>
              <TableHead className="py-2 px-4 border-b border-gray-300 text-left">
                Place
              </TableHead>
              <TableHead className="py-2 px-4 border-b border-gray-300 text-left">
                Date début
              </TableHead>
              <TableHead className="py-2 px-4 border-b border-gray-300 text-left">
                Date fin
              </TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {isPending ? (
              <TableRow>
                <TableCell rowSpan={4}>
                  <p>Chargement...</p>
                </TableCell>
              </TableRow>
            ) : error ? (
              <TableRow>
                <TableCell rowSpan={4}>
                  <p>Une error est survenue.</p>
                </TableCell>
              </TableRow>
            ) : (
              reservations.map((reservation, index) => (
                <TableRow key={index}>
                  <TableCell className="py-2 px-4 border-b border-gray-300">
                    <span className="font-bold">
                      {reservation.vehicle.maker}
                    </span>
                    {" - "}
                    <span className="border border-gray-300 p-1 rounded-sm bg-gray-100">
                      {reservation.vehicle.licencePlate}
                    </span>
                  </TableCell>
                  <TableCell className="py-2 px-4 border-b border-gray-300">
                    {reservation.place}
                  </TableCell>
                  <TableCell className="py-2 px-4 border-b border-gray-300">
                    {reservation.beginDate}
                  </TableCell>
                  <TableCell className="py-2 px-4 border-b border-gray-300">
                    {reservation.endDate}
                  </TableCell>
                </TableRow>
              ))
            )}
          </TableBody>
        </Table>
      </div>
    </div>
  );
}
