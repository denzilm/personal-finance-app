import styled from 'styled-components';

export const Input = styled.div`
  margin-block-end: 1rem;
  display: flex;
  flex-direction: column;

  input {
    outline: none;
    border: 1px solid var(--color-beige-200);
    background-color: var(--color-white-100);
    border-radius: 8px;
    padding: 0.75rem 0.5rem;
    font-family: inherit;
    color: var(--color-grey-400);
  }
`;

export const Error = styled.span`
  font-size: 0.875rem;
  color: var(--color-red-100);
  margin-block-start: 0.25rem;
`;
