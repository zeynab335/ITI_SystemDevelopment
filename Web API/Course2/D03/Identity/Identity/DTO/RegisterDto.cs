namespace Identity.DTO
{
    public record RegisterDto
    (
        string UserName,
        string Email,
        string Department,
        string Password
    );
        
}
