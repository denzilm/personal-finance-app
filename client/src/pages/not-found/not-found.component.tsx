import { NotFoundContainer, StatusContainer, StatusTextContainer } from './not-found.styles';

export function NotFound() {
  return (
    <NotFoundContainer>
      <StatusContainer>404&apos;d</StatusContainer>
      <StatusTextContainer>The page you were looking for does not exist!</StatusTextContainer>
    </NotFoundContainer>
  );
}
