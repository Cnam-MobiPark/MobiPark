import { useEffect, type ReactElement } from "react";
import { PageHeader } from "../../components/page_header";
import { useForm } from "react-hook-form";
import { format } from "date-fns";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Calendar } from "@/components/ui/calendar";
import { z } from "zod";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { cn } from "@/lib/utils";
import { CalendarIcon, TicketIcon } from "lucide-react";
import { fetchVehicles } from "@/api/vehicles";
import { useQuery } from "@tanstack/react-query";
import { Vehicle } from "@/api/types";

const formSchema = z.object({
  vehicle: z.string(),
  beginDate: z.date(),
  beginTime: z.string().time(),
  endDate: z.date(),
  endTime: z.string().time(),
});

function BookForm({ vehicles }: { vehicles: Vehicle[] }) {
  const form = useForm<z.infer<typeof formSchema>>();

  const beginDateValue = form.watch("beginDate");

  useEffect(() => {
    const endDate = form.watch("endDate");
    if (beginDateValue > endDate) {
      form.setValue("endDate", beginDateValue);
    }
  }, [beginDateValue]);

  function onSubmit() {}

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className="space-y-4 max-w-screen-md mx-auto"
      >
        <FormField
          control={form.control}
          name="vehicle"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Véhicule</FormLabel>
              <Select onValueChange={field.onChange} defaultValue={field.value}>
                <FormControl>
                  <SelectTrigger>
                    <SelectValue placeholder="Sélectionnez un véhicule" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  {vehicles.map((v) => (
                    <SelectItem value={v.licencePlate}>
                      {v.maker} - <i>{v.licencePlate}</i>
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <FormMessage />
            </FormItem>
          )}
        />

        <div className="flex flex-col md:flex-row gap-2">
          <FormField
            control={form.control}
            name="beginDate"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>Du</FormLabel>
                <Popover>
                  <PopoverTrigger asChild>
                    <FormControl>
                      <Button
                        variant="outline"
                        className={cn(
                          "w-[240px] pl-3 text-left font-normal",
                          !field.value && "text-muted-foreground"
                        )}
                      >
                        {field.value ? (
                          format(field.value, "PPP")
                        ) : (
                          <span>Sélectionnez une date</span>
                        )}
                        <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                      </Button>
                    </FormControl>
                  </PopoverTrigger>
                  <PopoverContent className="w-auto p-0" align="start">
                    <Calendar
                      mode="single"
                      selected={field.value}
                      onSelect={field.onChange}
                      disabled={(date) => date < new Date()}
                      initialFocus
                    />
                  </PopoverContent>
                </Popover>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="beginTime"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>Heure</FormLabel>
                <Input type="time" {...field} />
                <FormMessage />
              </FormItem>
            )}
          />
        </div>

        <div className="flex flex-col gap-2 md:flex-row">
          <FormField
            control={form.control}
            name="endDate"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>Au</FormLabel>
                <Popover>
                  <PopoverTrigger asChild>
                    <FormControl>
                      <Button
                        variant="outline"
                        className={cn(
                          "w-[240px] pl-3 text-left font-normal",
                          !field.value && "text-muted-foreground"
                        )}
                      >
                        {field.value ? (
                          format(field.value, "PPP")
                        ) : (
                          <span>Sélectionnez une date</span>
                        )}
                        <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                      </Button>
                    </FormControl>
                  </PopoverTrigger>
                  <PopoverContent className="w-auto p-0" align="start">
                    <Calendar
                      mode="single"
                      selected={field.value}
                      onSelect={field.onChange}
                      disabled={(date) =>
                        date < new Date() || date < beginDateValue
                      }
                      initialFocus
                    />
                  </PopoverContent>
                </Popover>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="endTime"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>Heure</FormLabel>
                <Input type="time" {...field} />
                <FormMessage />
              </FormItem>
            )}
          />
        </div>

        <div className="text-center pt-8">
          <Button
            type="submit"
            disabled={form.formState.isValid}
            className="gap-2"
          >
            <TicketIcon className="size-5" />
            Valider
          </Button>
        </div>
      </form>
    </Form>
  );
}

export function UserHome(): ReactElement {
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
        title="Faire une réservation"
        description="Réserver une place de parking pour votre véhicule"
      />

      {isPending ? (
        <p>Chargement...</p>
      ) : error ? (
        <p>Une erreur est survenu</p>
      ) : (
        <BookForm vehicles={vehicles} />
      )}
    </div>
  );
}
