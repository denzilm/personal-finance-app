import * as Yup from 'yup';

export const SignInValidationSchema = Yup.object().shape({
  email: Yup.string().email('Invalid email address').required("Can't be empty"),
  password: Yup.string().required("Can't be empty")
});
