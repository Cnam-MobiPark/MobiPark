import { type ReactElement } from "react";
import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Button, buttonVariants } from "@/components/ui/button";
import { UserPlusIcon } from "lucide-react";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { Input } from "@/components/ui/input";
import { Link } from "react-router-dom";
import { useAuth } from "@/context";
import { ConflictError } from "@/api/api";

const formSchema = z.object({
  username: z.string().min(2),
  password: z.string(),
});

export function Register(): ReactElement {
  const { register } = useAuth();
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      username: "",
      password: "",
    },
  });

  async function onSubmit(values: z.infer<typeof formSchema>) {
    try {
      await register(values.username, values.password);
    } catch (error) {
      if (error instanceof ConflictError) {
        form.setError("username", {
          type: "manual",
          message: "Username already exists.",
        });
        return;
      }

      if (error instanceof Error) {
        console.error(error);
      }
    }
  }

  return (
    <div className="min-h-screen bg-blue-50 flex flex-col justify-center items-center">
      <Card className="w-96">
        <CardHeader>
          <CardTitle className="text-center font-bold p-2 pb-0 text-4xl">
            MobiPark
          </CardTitle>
        </CardHeader>
        <CardContent>
          <Form {...form}>
            <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-4">
              <FormField
                control={form.control}
                name="username"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Username</FormLabel>
                    <FormControl>
                      <Input placeholder="Username" {...field} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />

              <FormField
                control={form.control}
                name="password"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Password</FormLabel>
                    <FormControl>
                      <Input
                        type="password"
                        placeholder="Password"
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <Button className="w-full gap-x-2">
                <UserPlusIcon className="size-5" />
                Register
              </Button>
            </form>
          </Form>
        </CardContent>
        <CardFooter className="justify-center">
          <Link
            className={buttonVariants({
              variant: "link",
              className: "p-0 h-auto",
            })}
            to="/login"
          >
            Already have an account?
          </Link>
        </CardFooter>
      </Card>
    </div>
  );
}
