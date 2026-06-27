namespace Application.Enums;

public enum ErrorCode
{
	None = 0,

    // Success
    Success = 200,

    // Client Errors
    BadRequest = 400,
    Validation = 400,

    Unauthorized = 401,
    Forbidden = 403,

    NotFound = 404,

    Conflict = 409,
    AlreadyExists = 409,

    // Server Errors
    InternalServerError = 500,
    DatabaseError = 500
}
