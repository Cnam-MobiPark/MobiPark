import { Vehicle } from "./types";
import { fetcherBody } from "./api";

export async function fetchVehicles(): Promise<Vehicle[]> {
  return fetcherBody("/api/Vehicle");
}
