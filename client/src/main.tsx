import React from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { ReactQueryDevtools } from '@tanstack/react-query-devtools';

import GlobalStyles from './global.styles';

import { AuthProvider } from './core/contexts/auth.context';
import { AxiosInstanceProvider } from './core/contexts/axios.context';

import App from './app';

const client = new QueryClient();
createRoot(document.querySelector('#root')!).render(
  <React.StrictMode>
    <BrowserRouter>
      <GlobalStyles />
      <AxiosInstanceProvider
        config={{
          baseURL: `${import.meta.env.VITE_BFF_BASE_URL}`,
          withCredentials: true,
          headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json; charset=utf-8'
          }
        }}
      >
        <QueryClientProvider client={client}>
          <ReactQueryDevtools initialIsOpen={false} />
          <AuthProvider>
            <App />
            <ToastContainer />
          </AuthProvider>
        </QueryClientProvider>
      </AxiosInstanceProvider>
    </BrowserRouter>
  </React.StrictMode>
);
