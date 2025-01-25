import { InputHTMLAttributes, ReactNode } from 'react';
import { useFormContext } from 'react-hook-form';

import { FormLabel } from './form-label.styles';
import { Input, Error } from './input-field.styles';
import { Info } from './info.styles';

type InputFieldProps = {
  name: string;
  label?: ReactNode;
  infoText?: string;
} & InputHTMLAttributes<HTMLInputElement>;

export function InputField({ name, label, infoText, ...otherProps }: InputFieldProps) {
  const { getFieldState, register } = useFormContext();
  const { error } = getFieldState(name);

  return (
    <Input>
      {label && <FormLabel>{label}</FormLabel>}
      <input {...otherProps} {...register(name)} />
      {infoText && <Info>{infoText}</Info>}
      {error && <Error>{error.message}</Error>}
    </Input>
  );
}
