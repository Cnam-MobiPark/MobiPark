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
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";

const formSchema = z.object({
  marque: z.string(),
  modele: z.string(),
  immatriculation: z.string(),
  taille: z.string(),
  energie: z.string(),
});

const vehicles = [
  {
    marque: "Renault",
    modele: "Scenic",
    immatriculation: "DH-456-JO",
    type: "Moyen",
    energie: "Combustion",
  },
  {
    marque: "Renault",
    modele: "Zoé",
    immatriculation: "BR-789-YT",
    type: "Petit",
    energie: "Électrique",
  },
];

export function MyVehicles(): ReactElement {
  const form = useForm<z.infer<typeof formSchema>>();

  function onSubmit(data: z.infer<typeof formSchema>) {
    console.log(data);
  }

return (
    <div>
      <PageHeader
        title="Mes véhicules"
        description="Gérer vos véhicules utilisés pour les réservations"
      />
      <div className="overflow-x-auto mb-16">
        <table className="min-w-full bg-white border border-gray-300">
          <thead>
            <tr>
              <th className="py-2 px-4 border-b border-gray-300 text-left">Marque</th>
              <th className="py-2 px-4 border-b border-gray-300 text-left">Modèle</th>
              <th className="py-2 px-4 border-b border-gray-300 text-left">Immatriculation</th>
              <th className="py-2 px-4 border-b border-gray-300 text-left">Taille</th>
              <th className="py-2 px-4 border-b border-gray-300 text-left">Énergie</th>
            </tr>
          </thead>
          <tbody>
            {vehicles.map((vehicle, index) => (
              <tr key={index}>
                <td className="py-2 px-4 border-b border-gray-300">{vehicle.marque}</td>
                <td className="py-2 px-4 border-b border-gray-300">{vehicle.modele}</td>
                <td className="py-2 px-4 border-b border-gray-300">{vehicle.immatriculation}</td>
                <td className="py-2 px-4 border-b border-gray-300">{vehicle.type}</td>
                <td className="py-2 px-4 border-b border-gray-300">{vehicle.energie}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      {/* Add Vehicle Form */}
      <PageHeader
        title="Ajouter un véhicule"
        description="Enregistrer un nouveau véhicule"
      />

      <Form {...form}>
        <form onSubmit={form.handleSubmit(onSubmit)} className="grid grid-cols-2 gap-4">
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
                <Select onValueChange={field.onChange} defaultValue={field.value}>
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Sélectionnez une taille" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="Petit">Petit</SelectItem>
                    <SelectItem value="Moyen">Moyen</SelectItem>
                    <SelectItem value="Grand">Grand</SelectItem>
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
                <Select onValueChange={field.onChange} defaultValue={field.value}>
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Sélectionnez une énergie" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="Électrique">Électrique</SelectItem>
                    <SelectItem value="Combustion">Combustion</SelectItem>
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