import React from 'react';
import { useParams } from 'react-router-dom';
import { PageHeader } from "../../components/page_header";
import {
  Table,
  TableBody,
  TableCell,
  TableRow,
} from "@/components/ui/table";

interface ConfirmationParams extends Record<string, string | undefined> {
  spotNumber: string;
}

// ParkingSpot Component
const ParkingSpot: React.FC<{ spotNumber: number; isSelected: boolean }> = ({ spotNumber, isSelected }) => (
  <div
    className={`flex items-center justify-center border rounded ${
      isSelected ? "bg-blue-600 text-white" : "bg-gray-300"
    }`}
    style={{ width: "100px", height: "50px" }}
  >
    {spotNumber}
  </div>
);

export const Confirmation: React.FC = () => {
  const { spotNumber } = useParams<ConfirmationParams>();
  const selectedSpotNumber = Number(spotNumber);

  const parkingLayout = [
    [1, null, 7, 13, null, 19],
    [2, null, 8, 14, null, 20],
    [3, null, 9, 15, null, 21],
    [4, null, 10, 16, null, 22],
    [null, null, null, null, null, 23],
    [null, null, null, null, null, 24],
    [5, null, 11, 17, null, 25],
    [6, null, 12, 18, null, 26],
  ];

  return (
    <div>
    <PageHeader title={`Place réservée ! Il s'agit de la place ${spotNumber}`} />
        {/* display parking slot info (elec etc) as description*/}

    <div className="flex flex-col items-center p-6 bg-white h-screen w-full max-w-4xl">
        <Table className="table-auto border-collapse border-none">
          <TableBody>
            {parkingLayout.map((row, rowIndex) => (
              <TableRow key={rowIndex} className="border-none">
                {row.map((spot, colIndex) => (
                  <TableCell key={colIndex} className="p-0 border-none" style={{ width: "50px", height: "70px" }}>
                    {spot !== null ? (
                      <ParkingSpot spotNumber={spot} isSelected={spot === selectedSpotNumber} />
                    ) : (
                      <div style={{ width: "90px", height: "50px" }} /> // vide
                    )}
                  </TableCell>
                ))}
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
    </div>
  );
};
