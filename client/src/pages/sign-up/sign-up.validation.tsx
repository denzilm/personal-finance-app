import * as Yup from 'yup';

export const SignUpValidationSchema = Yup.object().shape({
  firstName: Yup.string()
    .min(2, 'Must be two characters or more')
    .max(100, "Can't be more than 100 characters long")
    .required("Can't be empty"),
  lastName: Yup.string()
    .min(2, 'Must be two characters or more')
    .max(100, "Can't be more than 100 characters long")
    .required("Can't be empty"),
  email: Yup.string().email('Email must be a valid email address').required("Can't be empty"),
  password: Yup.string().min(8, 'Must be 8 characters or more').required("Can't be empty"),
  confirmPassword: Yup.string()
    .oneOf([Yup.ref('password')], 'Password does not match')
    .required("Can't be empty")
});
