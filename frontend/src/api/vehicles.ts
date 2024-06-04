import { Vehicle } from "@/types/vehicles";
import { fetcher } from "./fetcher";

export async function fetchVehicles(): Promise<Vehicle[]> {
  return fetcher("/api/Vehicle");
}
