import { fetchVehicles } from "@/api/vehicles";
import { QueryClient } from "@tanstack/react-query";
import { LoaderFunction } from "react-router-dom";

export function homeLoader(queryClient: QueryClient): LoaderFunction<void> {
  return async () => {
    try {
      const value = await queryClient.fetchQuery({
        queryKey: ["vehicles", "list"],
        queryFn: fetchVehicles,
      });

      return value;
    } catch (error) {
      /* empty */
    }
  };
}
