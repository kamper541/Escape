using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monadss{
public class Maybe<T> where T : class
{
    private readonly T value;

    public Maybe(T someValue)
    {
        if (someValue == null)
            throw new InvalidCastException("Nothing");
        else this.value = someValue;
    }

    public T get_value(){
        return value;
    }

    public Maybe()
    {
    }

    public Maybe<TO> Bind<TO>(System.Func<T, Maybe<TO>> func) where TO : class
    {
        return value != null ? func(value) : Maybe<TO>.None();
    }

    public static Maybe<T> None() => new Maybe<T>();

}

    public static class MaybeExtensions
    {
        public static Maybe<T> Return<T>(this T value) where T : class
        {
            return value != null ? new Maybe<T>(value) : Maybe<T>.None();
        }
    }


}
