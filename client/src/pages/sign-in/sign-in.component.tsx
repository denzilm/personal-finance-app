import { yupResolver } from '@hookform/resolvers/yup';

import { LogoContainer, SignInContentContainer, SignInFormContainer, SignInLinkContainer } from './sign-in.styles';

import { SignInRequest, useAuth } from '../../core/contexts/auth.context';

import { SignInValidationSchema } from './sign-in.validation';

import { FormContainer } from '../../core/components/form/form-container.styles';
import { FormTitle } from '../../core/components/form/form-title.styles';
import { StyledLink } from '../../core/components/common/styled-link.styles';
import { Form } from '../../core/components/form/form.component';
import { InputField } from '../../core/components/form/input-field.component';
import { SubmitButton } from '../../core/components/form/submit-button.component';

import { Logo } from '../../core/components/logo/logo.component';
import { LandingPageGraphic } from '../../core/components/auth/landing-page-graphic.component';

export function SignIn() {
  const { signInUser } = useAuth();

  return (
    <>
      <LogoContainer>
        <Logo />
      </LogoContainer>
      <SignInContentContainer>
        <LandingPageGraphic />
        <SignInFormContainer>
          <FormContainer>
            <FormTitle>Login</FormTitle>
            <Form<SignInRequest>
              defaultValues={{ email: undefined, password: undefined }}
              resolver={yupResolver(SignInValidationSchema)}
              onSubmit={async (signInRequest: SignInRequest) => await signInUser(signInRequest)}
            >
              <InputField name="email" label="Email" />
              <InputField name="password" label="password" type="password" />
              <SubmitButton>Login</SubmitButton>
            </Form>
            <SignInLinkContainer>
              Need to create an account? <StyledLink to="/sign-up">Sign Up</StyledLink>
            </SignInLinkContainer>
          </FormContainer>
        </SignInFormContainer>
      </SignInContentContainer>
    </>
  );
}
