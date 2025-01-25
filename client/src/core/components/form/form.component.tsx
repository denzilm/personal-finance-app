import { FieldValues, useForm, FormProvider, DefaultValues, Resolver, Mode } from 'react-hook-form';

type Props<T extends FieldValues> = {
  defaultValues?: DefaultValues<T>;
  children: React.ReactNode;
  onSubmit: (values: T) => void;
  resolver?: Resolver<T>;
  mode?: Mode;
};

export function Form<T extends FieldValues>({ defaultValues, resolver, children, onSubmit }: Props<T>) {
  const { handleSubmit, ...otherMethods } = useForm<T>({
    defaultValues: defaultValues,
    resolver: resolver
  });

  return (
    <FormProvider handleSubmit={handleSubmit} {...otherMethods}>
      <form onSubmit={handleSubmit(onSubmit)}>{children}</form>
    </FormProvider>
  );
}
