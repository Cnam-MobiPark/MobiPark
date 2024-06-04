export interface User {
  id: number;
  username: string;
}

export interface Vehicle {
  licencePlate: string;
  maker: string;
  engine: "Thermal" | "Electrical";
  type: "car" | "motorcycle";
}
