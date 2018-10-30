namespace RandomAnimalSounds
{
    public class AuthenticationResponse
    {
        private bool success = false;

        public static AuthenticationResponse InvalidSignatureCertChainUrl => new AuthenticationResponse();

        public static AuthenticationResponse ExpiredSignatureCert => new AuthenticationResponse();

        public static AuthenticationResponse Success(string body) => new AuthenticationResponse() { success = true, Body = body };

        public bool IsSuccess() => success;

        public bool IsFailure() => !success;

        public string Body { get; set; }
    }
}
