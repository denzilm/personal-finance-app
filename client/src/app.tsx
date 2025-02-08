import { Routes, Route, Navigate } from 'react-router-dom';

import { SignIn } from './pages/sign-in/sign-in.component';
import { SignUp } from './pages/sign-up/sign-up.component';
import { NotFound } from './pages/not-found/not-found.component';

export default function App() {
  return (
    <Routes>
      <Route path="/" element={<Navigate replace to="sign-in" />} />
      <Route path="sign-in" element={<SignIn />} />
      <Route path="sign-up" element={<SignUp />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
}
