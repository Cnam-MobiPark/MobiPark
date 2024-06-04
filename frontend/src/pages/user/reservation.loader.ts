import { fetchReservation } from "@/api/reservation";
import { QueryClient } from "@tanstack/react-query";
import { LoaderFunction } from "react-router-dom";

export function reservationLoader(
  queryClient: QueryClient
): LoaderFunction<void> {
  return async () => {
    try {
      const value = await queryClient.fetchQuery({
        queryKey: ["reservations", "list"],
        queryFn: fetchReservation,
      });

      return value;
    } catch (error) {
      /* empty */
    }
  };
}
