﻿using System.Security.Claims;
using System.Transactions;

namespace MeuPonto.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static TransactionContext CreateTransaction(this ClaimsPrincipal user)
    {
        var transaction = new TransactionContext(user);

        return transaction;
    }
}
