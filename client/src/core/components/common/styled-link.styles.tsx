import { Link } from 'react-router-dom';
import styled from 'styled-components';

export const StyledLink = styled(Link)`
  &:link,
  &:active,
  &:hover,
  &:visited {
    color: var(--color-grey-400);
  }
`;
