import React, { useEffect, useState } from "react";
import { type ReactElement } from "react";
import { PageHeader } from "../../components/page_header";
import { useForm } from "react-hook-form";
import { z } from "zod";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { fetchVehicles } from "@/api/vehicles";
import { useQuery } from "@tanstack/react-query";

interface Vehicle {
  marque: string;
  modele: string;
  immatriculation: string;
  type: string;
  energie: string;
}

const formSchema = z.object({
  marque: z.string(),
  modele: z.string(),
  immatriculation: z.string(),
  taille: z.string(),
  energie: z.string(),
});

export function MyVehicles(): ReactElement {
  const form = useForm<z.infer<typeof formSchema>>();

  function onSubmit(data: z.infer<typeof formSchema>) {
    console.log(data);
  }

  const {
    isPending,
    data: vehicles,
    error,
  } = useQuery({
    queryKey: ["vehicles", "list"],
    queryFn: () => fetchVehicles(),
  });

  return (
    <div>
      <PageHeader
        title="Mes véhicules"
        description="Gérer vos véhicules utilisés pour les réservations"
      />
      <div className="overflow-x-auto mb-16">
        <Table className="min-w-full bg-white border border-gray-300">
          <TableHeader>
            <TableRow>
              <TableHead className="py-2 px-4 border-b border-gray-300 text-left">
                Marque
              </TableHead>
              <TableHead className="py-2 px-4 border-b border-gray-300 text-left">
                Immatriculation
              </TableHead>
              <TableHead className="py-2 px-4 border-b border-gray-300 text-left">
                Taille
              </TableHead>
              <TableHead className="py-2 px-4 border-b border-gray-300 text-left">
                Énergie
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
              vehicles.map((vehicle, index) => (
                <TableRow key={index}>
                  <TableCell className="py-2 px-4 border-b border-gray-300">
                    {vehicle.maker}
                  </TableCell>
                  <TableCell className="py-2 px-4 border-b border-gray-300">
                    {vehicle.licencePlate}
                  </TableCell>
                  <TableCell className="py-2 px-4 border-b border-gray-300">
                    {vehicle.type}
                  </TableCell>
                  <TableCell className="py-2 px-4 border-b border-gray-300">
                    {vehicle.engine}
                  </TableCell>
                </TableRow>
              ))
            )}
          </TableBody>
        </Table>
      </div>
      {/* Add Vehicle Form */}
      <PageHeader
        title="Ajouter un véhicule"
        description="Enregistrer un nouveau véhicule"
      />

      <Form {...form}>
        <form
          onSubmit={form.handleSubmit(onSubmit)}
          className="grid grid-cols-2 gap-4"
        >
          <FormField
            control={form.control}
            name="marque"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Marque</FormLabel>
                <FormControl>
                  <Input placeholder="Marque" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="modele"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Modèle</FormLabel>
                <FormControl>
                  <Input placeholder="Modèle" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="immatriculation"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Immatriculation</FormLabel>
                <FormControl>
                  <Input placeholder="Immatriculation" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="taille"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Taille</FormLabel>
                <Select
                  onValueChange={field.onChange}
                  defaultValue={field.value}
                >
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Sélectionnez une taille" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="small">Petit</SelectItem>
                    <SelectItem value="medium">Moyen</SelectItem>
                    <SelectItem value="large">Grand</SelectItem>
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="energie"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Énergie</FormLabel>
                <Select
                  onValueChange={field.onChange}
                  defaultValue={field.value}
                >
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Sélectionnez une énergie" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="elec">Électrique</SelectItem>
                    <SelectItem value="gas">Combustion</SelectItem>
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />

          <div className="col-span-2 flex justify-end">
            <Button type="submit">Enregistrer</Button>
          </div>
        </form>
      </Form>
    </div>
  );
}
