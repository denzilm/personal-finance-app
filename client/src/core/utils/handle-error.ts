import axios from 'axios';
import { toast } from 'react-toastify';

export function handleError(error: unknown) {
  if (axios.isAxiosError(error)) {
    let message = '';
    if (error.code === 'ERR_NETWORK') message = 'A network related error occurred';

    if (error.response?.status === 400) message = Object.values(error.response.data?.errors).join('\n');

    toast.error(message, {
      autoClose: 5000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true
    });
  }
}
