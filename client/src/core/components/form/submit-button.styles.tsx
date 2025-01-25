import styled from 'styled-components';

type ButtonProps = { $isBusy: boolean };

export const StyledSubmitButton = styled.button<ButtonProps>`
  border: none;
  background-color: ${({ $isBusy }) => ($isBusy ? 'var(--color-grey-300)' : 'var(--color-grey-400)')};
  color: ${({ $isBusy }) => ($isBusy ? 'var(--color-grey-300)' : 'var(--color-white-100)')};
  padding: 1.25rem 1rem;
  border-radius: 8px;
  width: 100%;
  margin-top: 1rem;
  cursor: pointer;

  &:hover {
    opacity: 0.6;
  }
`;
