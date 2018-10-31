namespace RandomAnimalSounds
{
    public class AuthenticationResponse
    {
        private bool success = false;

        public static AuthenticationResponse InvalidSignatureCertChainUrl => new AuthenticationResponse() { Name = nameof(InvalidSignatureCertChainUrl) };

        public static AuthenticationResponse ExpiredOrNotYetValid => new AuthenticationResponse() { Name = nameof(ExpiredOrNotYetValid) };

        public static AuthenticationResponse ExpectedSanMissing => new AuthenticationResponse() { Name = nameof(ExpectedSanMissing) };

        public static AuthenticationResponse InvalidCertChain => new AuthenticationResponse() { Name = nameof(InvalidCertChain) };

        public static AuthenticationResponse InvalidSignature => new AuthenticationResponse() { Name = nameof(InvalidSignature) };

        public static AuthenticationResponse InvalidTimeStamp => new AuthenticationResponse() { Name = nameof(InvalidTimeStamp) };

        public static AuthenticationResponse Success(dynamic body) => new AuthenticationResponse() { success = true, Body = body, Name = "Success" };

        public bool IsSuccess() => success;

        public bool IsFailure() => !success;

        public dynamic Body { get; private set; }

        public string Name { get; private set; }
    }
}
