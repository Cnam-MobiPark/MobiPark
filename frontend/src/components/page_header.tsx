import { type ReactElement } from "react";

interface PageHeaderProps {
  title: string;
  description?: string;
}

export function PageHeader({
  title,
  description,
}: PageHeaderProps): ReactElement {
  return (
    <header className="mb-8">
      <h2 className="text-4xl font-bold mb-2">{title}</h2>

      {description && <p className="text-muted-foreground">{description}</p>}
    </header>
  );
}
