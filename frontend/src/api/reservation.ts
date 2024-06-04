import { fetcherBody } from "./api";
import { Reservation } from "./types";

export const fetchReservation = () =>
  fetcherBody<Reservation[]>(
    /*"/api/Reservation"*/ "/public/reservations.json"
  );
