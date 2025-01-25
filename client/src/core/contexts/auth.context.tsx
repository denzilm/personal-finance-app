import React from 'react';
import { useNavigate } from 'react-router-dom';

import { useAxios } from './axios.context';

import { handleError } from '../utils/handle-error';

export type SignUpRequest = {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword: string;
};

type User = {
  id: string;
} & Pick<SignUpRequest, 'email' | 'firstName' | 'lastName'>;

type AuthContextType = {
  user?: User;
  registerUser: (request: SignUpRequest) => Promise<void>;
};

const AuthContext = React.createContext<AuthContextType | undefined>(undefined);

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const axios = useAxios();
  const navigate = useNavigate();

  const registerUser = async (request: SignUpRequest) => {
    try {
      await axios.post<SignUpRequest>('/users/register', request);
      navigate('/sign-in');
    } catch (error) {
      handleError(error);
    }
  };

  const value = { registerUser };
  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}

export function useAuth() {
  const context = React.useContext(AuthContext);
  if (!context) {
    throw new Error('useAuth must be used within an AuthProvider');
  }

  return context;
}
