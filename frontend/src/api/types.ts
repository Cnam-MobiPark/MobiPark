export interface User {
  id: number;
  username: string;
}

export interface Reservation {
  vehicle: Vehicle;
  beginDate: string;
  endDate: string;
  place: string;
}

export interface Vehicle {
  licencePlate: string;
  maker: string;
  engine: "Thermal" | "Electrical";
  type: "car" | "motorcycle";
}
