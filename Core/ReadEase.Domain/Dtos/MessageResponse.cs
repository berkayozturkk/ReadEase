﻿namespace ReadEase.Domain.Dtos;

public sealed record MessageResponse(
    string Message, bool Result, object data);
