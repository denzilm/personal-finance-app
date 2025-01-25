import { ButtonHTMLAttributes } from 'react';
import { useFormContext } from 'react-hook-form';

import { StyledSubmitButton } from './submit-button.styles';

import { Spinner } from '../spinner/spinner.component';

type SubmitButtonProps = { children: React.ReactNode } & ButtonHTMLAttributes<HTMLButtonElement>;

export function SubmitButton({ children, ...rest }: SubmitButtonProps) {
  const {
    formState: { isSubmitting }
  } = useFormContext();

  return (
    <StyledSubmitButton $isBusy={isSubmitting} type="submit" {...rest}>
      <>
        {isSubmitting && <Spinner />}
        {!isSubmitting && children}
      </>
    </StyledSubmitButton>
  );
}
