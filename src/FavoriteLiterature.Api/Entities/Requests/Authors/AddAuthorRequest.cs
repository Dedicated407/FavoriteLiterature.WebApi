﻿using FavoriteLiterature.Client.Models.Authors;
using MediatR;

namespace FavoriteLiterature.Api.Entities.Requests.Authors;

public class AddAuthorRequest : AddAuthorRequestModel, IRequest
{
}