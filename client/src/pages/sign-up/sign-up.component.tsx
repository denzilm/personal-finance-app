import { yupResolver } from '@hookform/resolvers/yup';

import {
  SignUpContainer,
  LogoContainer,
  SignUpContentContainer,
  SignUpLinkContainer,
  SignupFormContainer
} from './sign-up.styles';

import { SignUpRequest, useAuth } from '../../core/contexts/auth.context';

import { SignUpValidationSchema } from './sign-up.validation';

import { FormContainer } from '../../core/components/form/form-container.styles';
import { FormTitle } from '../../core/components/form/form-title.styles';
import { StyledLink } from '../../core/components/common/styled-link.styles';
import { Form } from '../../core/components/form/form.component';
import { InputField } from '../../core/components/form/input-field.component';
import { SubmitButton } from '../../core/components/form/submit-button.component';

import { Logo } from '../../core/components/logo/logo.component';
import { LandingPageGraphic } from '../../core/components/auth/landing-page-graphic.component';

export function SignUp() {
  const { registerUser } = useAuth();
  return (
    <SignUpContainer>
      <LogoContainer>
        <Logo />
      </LogoContainer>
      <SignUpContentContainer>
        <LandingPageGraphic />
        <SignupFormContainer>
          <FormContainer>
            <FormTitle>Sign Up</FormTitle>
            <Form<SignUpRequest>
              defaultValues={{
                firstName: undefined,
                lastName: undefined,
                email: undefined,
                password: undefined,
                confirmPassword: undefined
              }}
              resolver={yupResolver(SignUpValidationSchema)}
              onSubmit={async (signUpRequest: SignUpRequest) => await registerUser(signUpRequest)}
            >
              <InputField name="firstName" label="First Name" />
              <InputField name="lastName" label="Last Name" />
              <InputField name="email" label="Email" />
              <InputField
                name="password"
                label="Password"
                type="password"
                infoText="Passwords must be at least 8 characters"
              />
              <InputField name="confirmPassword" label="Confirm Password" type="password" />
              <SubmitButton>Create Account</SubmitButton>
            </Form>
            <SignUpLinkContainer>
              Already have an account? <StyledLink to="/sign-in">Login</StyledLink>
            </SignUpLinkContainer>
          </FormContainer>
        </SignupFormContainer>
      </SignUpContentContainer>
    </SignUpContainer>
  );
}
