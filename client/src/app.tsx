import { Routes, Route, Navigate } from 'react-router-dom';

import { SignUp } from './pages/sign-up/sign-up.component';
import { NotFound } from './pages/not-found/not-found.component';

export default function App() {
  return (
    <Routes>
      <Route path="/" element={<Navigate replace to="sign-up" />} />
      <Route path="sign-up" element={<SignUp />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
}
