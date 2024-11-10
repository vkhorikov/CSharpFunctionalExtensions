using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests.ResultTests.Extensions;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class MatchTests_ValueTask : MatchTestsBase
{
    [Fact]
    public async Task Match_follows_some_branch_where_there_is_a_value()
    {
        Maybe<T> maybe = T.Value;
        var cancellationToken = GetCancellationToken();

        await maybe.Match(
            Some: (value, ct) =>
            {
                ct.Should().Be(cancellationToken);
                value.Should().Be(T.Value);

                return ValueTask.CompletedTask;
            },
            None: _ => throw new FieldAccessException("Accessed None path while maybe has value"),
            cancellationToken
        );
    }

    [Fact]
    public async Task Match_provides_context_to_some_selector()
    {
        Maybe<T> maybe = T.Value;
        var cancellationToken = GetCancellationToken();
        var context = 5;
        var contextAsserted = false;

        await maybe.Match(
            Some: (value, ctx, ct) =>
            {
                ct.Should().Be(cancellationToken);
                value.Should().Be(T.Value);
                ctx.Should().Be(context);
                contextAsserted = true;

                return ValueTask.CompletedTask;
            },
            None: (_, _) =>
                throw new FieldAccessException("Accessed None path while maybe has value"),
            context: context,
            cancellationToken
        );

        contextAsserted.Should().BeTrue();
    }

    [Fact]
    public async Task Match_follows_none_branch_where_is_no_value()
    {
        Maybe<T> maybe = null;
        var cancellationToken = GetCancellationToken();

        await maybe.Match(
            Some: (_, __) =>
                throw new FieldAccessException("Accessed Some path while maybe has no value"),
            None: (ct) =>
            {
                ct.Should().Be(cancellationToken);
                return ValueTask.CompletedTask;
            },
            cancellationToken
        );
    }

    [Fact]
    public async Task Match_provides_context_to_none_selector()
    {
        Maybe<T> maybe = null;
        var cancellationToken = GetCancellationToken();
        var context = 5;
        var contextAsserted = false;

        await maybe.Match(
            Some: (_, _, _) =>
                throw new FieldAccessException("Accessed Some path while maybe has no value"),
            None: (ctx, ct) =>
            {
                ctx.Should().Be(context);
                contextAsserted = true;
                ct.Should().Be(cancellationToken);

                return ValueTask.CompletedTask;
            },
            context: context,
            cancellationToken
        );

        contextAsserted.Should().BeTrue();
    }

    [Fact]
    public async Task Match_for_deconstruct_kv_follows_some_branch_where_is_no_value()
    {
        Maybe<KeyValuePair<int, string>> maybe = Maybe<KeyValuePair<int, string>>.From(
            new KeyValuePair<int, string>(42, "Matrix")
        );
        var cancellationToken = GetCancellationToken();

        await maybe.Match(
            Some: (intValue, stringValue, ct) =>
            {
                intValue.Should().Be(42);
                stringValue.Should().Be("Matrix");

                return ValueTask.CompletedTask;
            },
            None: _ => throw new FieldAccessException("Accessed None path while maybe has value"),
            cancellationToken
        );
    }

    [Fact]
    public async Task Match_for_deconstruct_kv_provides_context_to_some_selector()
    {
        Maybe<KeyValuePair<int, string>> maybe = Maybe<KeyValuePair<int, string>>.From(
            new KeyValuePair<int, string>(42, "Matrix")
        );
        var cancellationToken = GetCancellationToken();
        var context = 5;
        var contextAsserted = false;

        await maybe.Match(
            Some: (intValue, stringValue, ctx, ct) =>
            {
                intValue.Should().Be(42);
                stringValue.Should().Be("Matrix");
                ctx.Should().Be(context);
                contextAsserted = true;

                return ValueTask.CompletedTask;
            },
            None: (_, _) =>
                throw new FieldAccessException("Accessed None path while maybe has value"),
            context: context,
            cancellationToken
        );

        contextAsserted.Should().BeTrue();
    }

    [Fact]
    public async Task Match_for_deconstruct_kv_follows_none_branch_where_is_no_value()
    {
        Maybe<KeyValuePair<int, string>> maybe = Maybe<KeyValuePair<int, string>>.None;
        var cancellationToken = GetCancellationToken();

        await maybe.Match(
            Some: (_, __, ___) =>
                throw new FieldAccessException("Accessed Some path while maybe has no value"),
            None: (ct) =>
            {
                ct.Should().Be(cancellationToken);
                return ValueTask.CompletedTask;
            },
            cancellationToken
        );
    }

    [Fact]
    public async Task Match_for_deconstruct_kv_provides_context_to_none_selector()
    {
        Maybe<KeyValuePair<int, string>> maybe = Maybe<KeyValuePair<int, string>>.None;
        var cancellationToken = GetCancellationToken();
        var context = 5;
        var contextAsserted = false;

        await maybe.Match(
            Some: (_, _, _, _) =>
                throw new FieldAccessException("Accessed Some path while maybe has no value"),
            None: (ctx, ct) =>
            {
                ctx.Should().Be(context);
                contextAsserted = true;
                ct.Should().Be(cancellationToken);

                return ValueTask.CompletedTask;
            },
            context: context,
            cancellationToken
        );

        contextAsserted.Should().BeTrue();
    }

    [Fact]
    public async Task Match_for_deconstruct_kv_follows_some_branch_where_is_a_return_value()
    {
        Maybe<KeyValuePair<int, string>> maybe = Maybe<KeyValuePair<int, string>>.From(
            new KeyValuePair<int, string>(42, "Matrix")
        );
        var cancellationToken = GetCancellationToken();

        var returnValue = await maybe.Match(
            Some: (intValue, stringValue, ct) =>
            {
                intValue.Should().Be(42);
                stringValue.Should().Be("Matrix");

                return intValue.AsValueTask();
            },
            None: _ => throw new FieldAccessException("Accessed None path while maybe has value"),
            cancellationToken
        );

        42.Should().Be(returnValue);
    }

    [Fact]
    public async Task Match_for_deconstruct_kv_with_return_value_provides_context_to_some_selector()
    {
        Maybe<KeyValuePair<int, string>> maybe = Maybe<KeyValuePair<int, string>>.From(
            new KeyValuePair<int, string>(42, "Matrix")
        );
        var cancellationToken = GetCancellationToken();
        var context = 5;
        var contextAsserted = false;

        var returnValue = await maybe.Match(
            Some: (intValue, stringValue, ctx, ct) =>
            {
                ctx.Should().Be(context);
                contextAsserted = true;

                return intValue.AsValueTask();
            },
            None: (_, _) =>
                throw new FieldAccessException("Accessed None path while maybe has value"),
            context: context,
            cancellationToken
        );

        42.Should().Be(returnValue);
        contextAsserted.Should().BeTrue();
    }

    [Fact]
    public async Task Match_for_deconstruct_kv_follows_none_branch_where_is_a_return_value()
    {
        Maybe<KeyValuePair<int, string>> maybe = Maybe<KeyValuePair<int, string>>.None;
        var cancellationToken = GetCancellationToken();

        var returnValue = await maybe.Match(
            Some: (_, __, ___) =>
                throw new FieldAccessException("Accessed Some path while maybe has no value"),
            None: (ct) =>
            {
                ct.Should().Be(cancellationToken);
                return (-1).AsValueTask();
            },
            cancellationToken
        );

        (-1).Should().Be(returnValue);
    }

    [Fact]
    public async Task Match_for_deconstruct_kv_with_return_value_provides_context_to_none_selector()
    {
        Maybe<KeyValuePair<int, string>> maybe = Maybe<KeyValuePair<int, string>>.None;
        var context = 5;
        var contextAsserted = false;
        var cancellationToken = GetCancellationToken();

        var returnValue = await maybe.Match(
            Some: (intValue, stringValue, ctx, ct) =>
                throw new FieldAccessException("Accessed Some path while maybe has no value"),
            None: (ctx, _) =>
            {
                ctx.Should().Be(context);
                contextAsserted = true;

                return (-1).AsValueTask();
            },
            context: context,
            cancellationToken
        );

        (-1).Should().Be(returnValue);
        contextAsserted.Should().BeTrue();
    }

    private static CancellationToken GetCancellationToken() => new(canceled: true);
}
