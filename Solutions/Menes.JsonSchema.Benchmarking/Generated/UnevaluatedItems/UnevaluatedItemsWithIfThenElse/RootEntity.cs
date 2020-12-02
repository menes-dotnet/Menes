// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace UnevaluatedItemsFeature.UnevaluatedItemsWithIfThenElse
{
    public readonly struct RootEntity : Menes.IJsonValue, Menes.IJsonArray<RootEntity, Menes.JsonAny>
    {
        public static readonly RootEntity Null = default(RootEntity);
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? _menesArrayValueBacking;
        public RootEntity(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
            this._menesArrayValueBacking = default;
        }
        public RootEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> value)
        {
            this._menesArrayValueBacking = value;
            this._menesJsonElementBacking = default;
        }
        public static implicit operator RootEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> items)
        {
            return new RootEntity(items);
        }
        /// <inheritdoc />
        public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
        /// <inheritdoc />
        public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
        /// <inheritdoc />
        public bool IsNumber => false;
        /// <inheritdoc />
        public bool IsInteger => false;
        /// <inheritdoc />
        public bool IsString => false;
        /// <inheritdoc />
        public bool IsObject => false;
        /// <inheritdoc />
        public bool IsBoolean => false;
        /// <inheritdoc />
        public bool IsArray => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Array) || (!this.HasJsonElement && this._menesArrayValueBacking is not null);
        /// <inheritdoc />
        public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        /// <inheritdoc />
        public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
        /// <inheritdoc />
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
        {
            Menes.ValidationContext result = validationContext;
            if (level != Menes.ValidationLevel.Flag)
            {
                result = result.UsingStack();
            }
            if (!this.IsArray)
            {
                if (level >= Menes.ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of array");
                }
                else
                {
                    result = result.WithResult(isValid: false);
                }
                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                {
                    return result;
                }
            }
            result = ValidateIfThenElse(this, result, level);
            if (!this.IsArray)
            {
                if (level >= Menes.ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, message: "6.1.1. type - expected an array type.");
                }
                else
                {
                    result = result.WithResult(isValid: false);
                }
                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                {
                    return result;
                }
            }
            if (this.IsArray)
            {
                int arrayLength = 0;
                var arrayEnumerator = this.EnumerateArray();
                while (arrayEnumerator.MoveNext())
                {
                    switch (arrayLength)
                    {
                        case 0:
                            result = arrayEnumerator.Current.As<RootEntity.Items0Entity>().Validate(result, level);
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                            {
                                return result;
                            }
                            result = result.WithLocalItemIndex(arrayLength);
                            break;
                        default:
                            if (!result.HasEvaluatedLocalOrAppliedItemIndex(arrayLength))
                            {
                                result = arrayEnumerator.Current.As<Menes.JsonNotAny>().Validate(result, level);
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
                                result = result.WithLocalItemIndex(arrayLength);
                            }
                            break;
                    }
                    arrayLength++;
                }
            }
            return result;
            Menes.ValidationContext ValidateIfThenElse(in RootEntity that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level)
            {
                var ifValue = that.AsIfEntity();
                Menes.ValidationContext ifResult;
                if (level == Menes.ValidationLevel.Flag)
                {
                    ifResult = ifValue.Validate(validationContext.CreateChildContext(), level);
                }
                else
                {
                    ifResult = ifValue.Validate(validationContext.CreateChildContext("#/if"), level);
                }
                if (ifResult.IsValid)
                {
                    result = result.MergeChildContext(ifResult, false);
                    var thenValue = that.AsThenEntity();
                    Menes.ValidationContext thenResult;
                    if (level == Menes.ValidationLevel.Flag)
                    {
                        thenResult = thenValue.Validate(validationContext.CreateChildContext(), level);
                    }
                    else
                    {
                        thenResult = thenValue.Validate(validationContext.CreateChildContext("#/then"), level);
                    }
                    if (!thenResult.IsValid)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "9.2.2.2. then");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                    }
                    else
                    {
                        result = result.MergeChildContext(thenResult, false);
                        if (level == Menes.ValidationLevel.Verbose)
                        {
                            result = result.WithResult(isValid: true);
                        }
                    }
                }
                else
                {
                    var elseValue = that.AsElseEntity();
                    Menes.ValidationContext elseResult;
                    if (level == Menes.ValidationLevel.Flag)
                    {
                        elseResult = elseValue.Validate(validationContext.CreateChildContext(), level);
                    }
                    else
                    {
                        elseResult = elseValue.Validate(validationContext.CreateChildContext("#/else"), level);
                    }
                    if (!elseResult.IsValid)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "9.2.2.3. else");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                    }
                    else
                    {
                        if (level == Menes.ValidationLevel.Verbose)
                        {
                            result = result.WithResult(isValid: true);
                        }
                        result = result.MergeChildContext(elseResult, false);
                    }
                }
                return result;
            }
        }
        /// <inheritdoc />
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
                return;
            }
            writer.WriteStartArray();
            foreach (var item in this._menesArrayValueBacking)
            {
                item.WriteTo(writer);
            }
            writer.WriteEndArray();
        }
        /// <inheritdoc />
        public T As<T>()
            where T : struct, Menes.IJsonValue
        {
            if (typeof(T) == typeof(RootEntity))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }
            return Menes.JsonValue.As<RootEntity, T>(this);
        }
        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, Menes.IJsonValue
        {
            if (typeof(T) == typeof(RootEntity))
            {
                return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
            }
            return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
        }
        public readonly RootEntity.IfEntity AsIfEntity()
        {
            return this.As<RootEntity.IfEntity>();
        }
        public readonly RootEntity.ThenEntity AsThenEntity()
        {
            return this.As<RootEntity.ThenEntity>();
        }
        public readonly RootEntity.ElseEntity AsElseEntity()
        {
            return this.As<RootEntity.ElseEntity>();
        }
        /// <inheritdoc/>
        public bool Equals<T>(in T other)
            where T : struct, Menes.IJsonValue
        {
            if (!other.IsArray)
            {
                return false;
            }
            MenesArrayEnumerator firstEnumerator = this.EnumerateArray();
            Menes.JsonAny.MenesArrayEnumerator secondEnumerator = other.As<Menes.JsonAny>().EnumerateArray();
            while (firstEnumerator.MoveNext())
            {
                if (!secondEnumerator.MoveNext())
                {
                    // We've run out of items in the second enumerator.
                    return false;
                }
                if (!firstEnumerator.Current.Equals(secondEnumerator.Current))
                {
                    return false;
                }
            }
            // If we have extra items in the second enumerator, return false.
            return !secondEnumerator.MoveNext();
        }
        public RootEntity.MenesArrayEnumerator GetEnumerator()
        {
            return new RootEntity.MenesArrayEnumerator(this);
        }
        public RootEntity.MenesArrayEnumerator EnumerateArray()
        {
            return new RootEntity.MenesArrayEnumerator(this);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        /// <inheritdoc />
        public int GetArrayLength()
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.GetArrayLength();
            }
            return this._menesArrayValueBacking?.Length ?? 0;
        }
        /// <inheritdoc />
        public T GetItemAtIndex<T>(int index)
            where T : struct, Menes.IJsonValue
        {
            if (this.HasJsonElement)
            {
                int currentIndex = 0;
                foreach (var item in this.JsonElement.EnumerateArray())
                {
                    if (currentIndex == index)
                    {
                        return Menes.JsonValue.As<T>(item);
                    }
                }
                throw new System.IndexOutOfRangeException();
            }
            if (this._menesArrayValueBacking is not null)
            {
                return this._menesArrayValueBacking.Value[index].As<T>();
            }
            return default;
        }
        public RootEntity Add<T1>(T1 item1)
            where T1 : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                arrayBuilder.Add(oldItem);
            }
            arrayBuilder.Add(item1.As<Menes.JsonAny>());
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Add<T1, T2>(T1 item1, T2 item2)
            where T1 : struct, Menes.IJsonValue
            where T2 : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                arrayBuilder.Add(oldItem);
            }
            arrayBuilder.Add(item1.As<Menes.JsonAny>());
            arrayBuilder.Add(item2.As<Menes.JsonAny>());
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
            where T1 : struct, Menes.IJsonValue
            where T2 : struct, Menes.IJsonValue
            where T3 : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                arrayBuilder.Add(oldItem);
            }
            arrayBuilder.Add(item1.As<Menes.JsonAny>());
            arrayBuilder.Add(item2.As<Menes.JsonAny>());
            arrayBuilder.Add(item3.As<Menes.JsonAny>());
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
            where T1 : struct, Menes.IJsonValue
            where T2 : struct, Menes.IJsonValue
            where T3 : struct, Menes.IJsonValue
            where T4 : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                arrayBuilder.Add(oldItem);
            }
            arrayBuilder.Add(item1.As<Menes.JsonAny>());
            arrayBuilder.Add(item2.As<Menes.JsonAny>());
            arrayBuilder.Add(item3.As<Menes.JsonAny>());
            arrayBuilder.Add(item4.As<Menes.JsonAny>());
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Add<T>(params T[] items)
            where T : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                arrayBuilder.Add(oldItem);
            }
            foreach (var item1 in items)
            {
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
            }
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Insert<T>(int index, T item1)
            where T : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            int currentIndex = 0;
            bool inserted = false;
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                if (currentIndex == index)
                {
                    arrayBuilder.Add(item1.As<Menes.JsonAny>());
                    inserted = true;
                }
                arrayBuilder.Add(oldItem);
                currentIndex++;
            }
            if (!inserted)
            {
                throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
            }
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Insert<T1, T2>(int index, T1 item1, T2 item2)
            where T1 : struct, Menes.IJsonValue
            where T2 : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            int currentIndex = 0;
            bool inserted = false;
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                if (currentIndex == index)
                {
                    arrayBuilder.Add(item1.As<Menes.JsonAny>());
                    arrayBuilder.Add(item2.As<Menes.JsonAny>());
                    inserted = true;
                }
                arrayBuilder.Add(oldItem);
                currentIndex++;
            }
            if (!inserted)
            {
                throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
            }
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
            where T1 : struct, Menes.IJsonValue
            where T2 : struct, Menes.IJsonValue
            where T3 : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            int currentIndex = 0;
            bool inserted = false;
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                if (currentIndex == index)
                {
                    arrayBuilder.Add(item1.As<Menes.JsonAny>());
                    arrayBuilder.Add(item2.As<Menes.JsonAny>());
                    arrayBuilder.Add(item3.As<Menes.JsonAny>());
                    inserted = true;
                }
                arrayBuilder.Add(oldItem);
                currentIndex++;
            }
            if (!inserted)
            {
                throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
            }
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
            where T1 : struct, Menes.IJsonValue
            where T2 : struct, Menes.IJsonValue
            where T3 : struct, Menes.IJsonValue
            where T4 : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            int currentIndex = 0;
            bool inserted = false;
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                if (currentIndex == index)
                {
                    arrayBuilder.Add(item1.As<Menes.JsonAny>());
                    arrayBuilder.Add(item2.As<Menes.JsonAny>());
                    arrayBuilder.Add(item3.As<Menes.JsonAny>());
                    arrayBuilder.Add(item4.As<Menes.JsonAny>());
                    inserted = true;
                }
                arrayBuilder.Add(oldItem);
                currentIndex++;
            }
            if (!inserted)
            {
                throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
            }
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Insert<T>(int index, params T[] items)
            where T : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            int currentIndex = 0;
            bool inserted = false;
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                if (currentIndex == index)
                {
                    foreach (var item1 in items)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                    }
                    inserted = true;
                }
                arrayBuilder.Add(oldItem);
                currentIndex++;
            }
            if (!inserted)
            {
                throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
            }
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity RemoveAt(int index)
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            int currentIndex = 0;
            bool removed = false;
            foreach (var item in this._menesArrayValueBacking)
            {
                if (currentIndex != index)
                {
                    arrayBuilder.Add(item);
                }
                else
                {
                    removed = true;
                }
                currentIndex++;
            }
            if (!removed)
            {
                throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
            }
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity RemoveIf(System.Predicate<Menes.JsonAny> condition)
        {
            return this.RemoveIf<Menes.JsonAny>(condition);
        }
        public RootEntity RemoveIf<T>(System.Predicate<T> condition)
            where T : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (var item in this._menesArrayValueBacking)
            {
                if (!condition(item.As<T>()))
                {
                    arrayBuilder.Add(item);
                }
            }
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        private bool AllBackingFieldsAreNull()
        {
            if (this._menesArrayValueBacking is not null)
            {
                return false;
            }
            return true;
        }
        public readonly struct IfEntity : Menes.IJsonValue, Menes.IJsonArray<IfEntity, Menes.JsonAny>
        {
            public static readonly IfEntity Null = default(IfEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? _menesArrayValueBacking;
            public IfEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesArrayValueBacking = default;
            }
            public IfEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> value)
            {
                this._menesArrayValueBacking = value;
                this._menesJsonElementBacking = default;
            }
            public static implicit operator IfEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> items)
            {
                return new RootEntity.IfEntity(items);
            }
            /// <inheritdoc />
            public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
            /// <inheritdoc />
            public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
            /// <inheritdoc />
            public bool IsNumber => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number;
            /// <inheritdoc />
            public bool IsInteger => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number;
            /// <inheritdoc />
            public bool IsString => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.String;
            /// <inheritdoc />
            public bool IsObject => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object;
            /// <inheritdoc />
            public bool IsBoolean => this.HasJsonElement && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.True || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.False);
            /// <inheritdoc />
            public bool IsArray => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Array;
            /// <inheritdoc />
            public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            /// <inheritdoc />
            public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
            /// <inheritdoc />
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
                if (level != Menes.ValidationLevel.Flag)
                {
                    result = result.UsingStack();
                }
                if (this.IsArray)
                {
                    int arrayLength = 0;
                    var arrayEnumerator = this.EnumerateArray();
                    while (arrayEnumerator.MoveNext())
                    {
                        switch (arrayLength)
                        {
                            case 0:
                                result = arrayEnumerator.Current.As<Menes.JsonAny>().Validate(result, level);
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
                                result = result.WithLocalItemIndex(arrayLength);
                                break;
                            case 1:
                                result = arrayEnumerator.Current.As<RootEntity.IfEntity.Items1Entity>().Validate(result, level);
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
                                result = result.WithLocalItemIndex(arrayLength);
                                break;
                            default:
                                break;
                        }
                        arrayLength++;
                    }
                }
                return result;
            }
            /// <inheritdoc />
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                    return;
                }
                writer.WriteStartArray();
                foreach (var item in this._menesArrayValueBacking)
                {
                    item.WriteTo(writer);
                }
                writer.WriteEndArray();
            }
            /// <inheritdoc />
            public T As<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(IfEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<IfEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.IfEntity))
                {
                    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(in T other)
                where T : struct, Menes.IJsonValue
            {
                return false;
            }
            public RootEntity.IfEntity.MenesArrayEnumerator GetEnumerator()
            {
                return new RootEntity.IfEntity.MenesArrayEnumerator(this);
            }
            public RootEntity.IfEntity.MenesArrayEnumerator EnumerateArray()
            {
                return new RootEntity.IfEntity.MenesArrayEnumerator(this);
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            /// <inheritdoc />
            public int GetArrayLength()
            {
                if (this.HasJsonElement)
                {
                    return this.JsonElement.GetArrayLength();
                }
                return this._menesArrayValueBacking?.Length ?? 0;
            }
            /// <inheritdoc />
            public T GetItemAtIndex<T>(int index)
                where T : struct, Menes.IJsonValue
            {
                if (this.HasJsonElement)
                {
                    int currentIndex = 0;
                    foreach (var item in this.JsonElement.EnumerateArray())
                    {
                        if (currentIndex == index)
                        {
                            return Menes.JsonValue.As<T>(item);
                        }
                    }
                    throw new System.IndexOutOfRangeException();
                }
                if (this._menesArrayValueBacking is not null)
                {
                    return this._menesArrayValueBacking.Value[index].As<T>();
                }
                return default;
            }
            public IfEntity Add<T1>(T1 item1)
                where T1 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                return new RootEntity.IfEntity(arrayBuilder.ToImmutable());
            }
            public IfEntity Add<T1, T2>(T1 item1, T2 item2)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                arrayBuilder.Add(item2.As<Menes.JsonAny>());
                return new RootEntity.IfEntity(arrayBuilder.ToImmutable());
            }
            public IfEntity Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                arrayBuilder.Add(item2.As<Menes.JsonAny>());
                arrayBuilder.Add(item3.As<Menes.JsonAny>());
                return new RootEntity.IfEntity(arrayBuilder.ToImmutable());
            }
            public IfEntity Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
                where T4 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                arrayBuilder.Add(item2.As<Menes.JsonAny>());
                arrayBuilder.Add(item3.As<Menes.JsonAny>());
                arrayBuilder.Add(item4.As<Menes.JsonAny>());
                return new RootEntity.IfEntity(arrayBuilder.ToImmutable());
            }
            public IfEntity Add<T>(params T[] items)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                foreach (var item1 in items)
                {
                    arrayBuilder.Add(item1.As<Menes.JsonAny>());
                }
                return new RootEntity.IfEntity(arrayBuilder.ToImmutable());
            }
            public IfEntity Insert<T>(int index, T item1)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.IfEntity(arrayBuilder.ToImmutable());
            }
            public IfEntity Insert<T1, T2>(int index, T1 item1, T2 item2)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        arrayBuilder.Add(item2.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.IfEntity(arrayBuilder.ToImmutable());
            }
            public IfEntity Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        arrayBuilder.Add(item2.As<Menes.JsonAny>());
                        arrayBuilder.Add(item3.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.IfEntity(arrayBuilder.ToImmutable());
            }
            public IfEntity Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
                where T4 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        arrayBuilder.Add(item2.As<Menes.JsonAny>());
                        arrayBuilder.Add(item3.As<Menes.JsonAny>());
                        arrayBuilder.Add(item4.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.IfEntity(arrayBuilder.ToImmutable());
            }
            public IfEntity Insert<T>(int index, params T[] items)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        foreach (var item1 in items)
                        {
                            arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        }
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.IfEntity(arrayBuilder.ToImmutable());
            }
            public IfEntity RemoveAt(int index)
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool removed = false;
                foreach (var item in this._menesArrayValueBacking)
                {
                    if (currentIndex != index)
                    {
                        arrayBuilder.Add(item);
                    }
                    else
                    {
                        removed = true;
                    }
                    currentIndex++;
                }
                if (!removed)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.IfEntity(arrayBuilder.ToImmutable());
            }
            public IfEntity RemoveIf(System.Predicate<Menes.JsonAny> condition)
            {
                return this.RemoveIf<Menes.JsonAny>(condition);
            }
            public IfEntity RemoveIf<T>(System.Predicate<T> condition)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var item in this._menesArrayValueBacking)
                {
                    if (!condition(item.As<T>()))
                    {
                        arrayBuilder.Add(item);
                    }
                }
                return new RootEntity.IfEntity(arrayBuilder.ToImmutable());
            }
            private bool AllBackingFieldsAreNull()
            {
                if (this._menesArrayValueBacking is not null)
                {
                    return false;
                }
                return true;
            }
            public readonly struct Items1Entity : Menes.IJsonValue
            {
                public static readonly Items1Entity Null = default(Items1Entity);
                private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
                private readonly Menes.JsonString? _menesStringTypeBacking;
                private static readonly Menes.JsonString _MenesConstValue = new Menes.JsonString("bar");
                public Items1Entity(System.Text.Json.JsonElement jsonElement)
                {
                    this._menesJsonElementBacking = jsonElement;
                    this._menesStringTypeBacking = default;
                }
                public Items1Entity(Menes.JsonString value)
                {
                    this._menesJsonElementBacking = default;
                    this._menesStringTypeBacking = value;
                }
                private Items1Entity(Menes.JsonString? _menesStringTypeBacking)
                {
                    this._menesJsonElementBacking = default;
                    this._menesStringTypeBacking = _menesStringTypeBacking;
                }
                public static implicit operator Menes.JsonString(Items1Entity value)
                {
                    return value.As<Menes.JsonString>();
                }
                public static implicit operator Items1Entity(Menes.JsonString value)
                {
                    return value.As<RootEntity.IfEntity.Items1Entity>();
                }
                public static implicit operator string(Items1Entity value)
                {
                    return (string)(Menes.JsonString)value;
                }
                public static implicit operator Items1Entity(string value)
                {
                    return (RootEntity.IfEntity.Items1Entity)(Menes.JsonString)value;
                }
                /// <inheritdoc />
                public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
                /// <inheritdoc />
                public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
                /// <inheritdoc />
                public bool IsNumber => false;
                /// <inheritdoc />
                public bool IsInteger => false;
                /// <inheritdoc />
                public bool IsString => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.String) || (!this.HasJsonElement && this._menesStringTypeBacking is not null);
                /// <inheritdoc />
                public bool IsObject => false;
                /// <inheritdoc />
                public bool IsBoolean => false;
                /// <inheritdoc />
                public bool IsArray => false;
                /// <inheritdoc />
                public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
                /// <inheritdoc />
                public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
                /// <inheritdoc />
                public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
                {
                    Menes.ValidationContext result = validationContext;
                    if (level != Menes.ValidationLevel.Flag)
                    {
                        result = result.UsingStack();
                    }
                    if (!this.IsString)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of string");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                    }
                    if (!this.IsString)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"bar\"");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                    }
                    else
                    {
                        if (!System.MemoryExtensions.SequenceEqual(this.As<Menes.JsonString>().AsSpan(), _MenesConstValue.AsSpan()))
                        {
                            if (level >= Menes.ValidationLevel.Basic)
                            {
                                result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"bar\"");
                            }
                            else
                            {
                                result = result.WithResult(isValid: false);
                            }
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                            {
                                return result;
                            }
                        }
                        else
                        {
                            if (level == Menes.ValidationLevel.Verbose)
                            {
                                result = result.WithResult(isValid: true);
                            }
                        }
                    }
                    return result;
                }
                /// <inheritdoc />
                public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
                {
                    if (this.HasJsonElement)
                    {
                        this.JsonElement.WriteTo(writer);
                        return;
                    }
                    this._menesStringTypeBacking?.WriteTo(writer);
                }
                /// <inheritdoc />
                public T As<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(Items1Entity))
                    {
                        return Corvus.Extensions.CastTo<T>.From(this);
                    }
                    return Menes.JsonValue.As<Items1Entity, T>(this);
                }
                /// <inheritdoc />
                public bool Is<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(RootEntity.IfEntity.Items1Entity))
                    {
                        return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                    }
                    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                /// <inheritdoc/>
                public bool Equals<T>(in T other)
                    where T : struct, Menes.IJsonValue
                {
                    if (!other.IsString)
                    {
                        return false;
                    }
                    return ((Menes.JsonString)this).Equals(other);
                }
                private bool AllBackingFieldsAreNull()
                {
                    if (this._menesStringTypeBacking is not null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            /// <summary>
            /// An enumerator for the array values in a <see cref="IfEntity"/>.
            /// </summary>
            public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonAny>, System.Collections.IEnumerator
            {
                private IfEntity instance;
                private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                internal MenesArrayEnumerator(IfEntity instance)
                {
                    this.instance = instance;
                    if (this.instance.HasJsonElement)
                    {
                        this.index = -2;
                        this.hasJsonEnumerator = true;
                        this.jsonEnumerator = this.instance.JsonElement.EnumerateArray();
                    }
                    else
                    {
                        this.index = -1;
                        this.hasJsonEnumerator = false;
                        this.jsonEnumerator = default;
                    }
                }
                /// <inheritdoc/>
                public Menes.JsonAny Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.JsonAny(this.jsonEnumerator.Current);
                        }
                        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonAny> array && this.index >= 0 && this.index < array.Length)
                        {
                            return array[this.index];
                        }
                        return default;
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the array values in a <see cref="IfEntity"/>.</returns>
                public MenesArrayEnumerator GetEnumerator()
                {
                    MenesArrayEnumerator result = this;
                    result.Reset();
                    return result;
                }
                /// <inheritdoc/>
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                /// <inheritdoc/>
                System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                /// <inheritdoc/>
                public void Dispose()
                {
                    if (this.hasJsonEnumerator)
                    {
                        this.jsonEnumerator.Dispose();
                    }
                }
                /// <inheritdoc/>
                public void Reset()
                {
                    if (this.hasJsonEnumerator)
                    {
                        this.jsonEnumerator.Reset();
                    }
                    else
                    {
                        this.index = -1;
                    }
                }
                /// <inheritdoc/>
                public bool MoveNext()
                {
                    if (this.hasJsonEnumerator)
                    {
                        return this.jsonEnumerator.MoveNext();
                    }
                    else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonAny> array && this.index + 1 < array.Length)
                    {
                        this.index++;
                        return true;
                    }
                    return false;
                }
            }
        }
        public readonly struct ThenEntity : Menes.IJsonValue, Menes.IJsonArray<ThenEntity, Menes.JsonAny>
        {
            public static readonly ThenEntity Null = default(ThenEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? _menesArrayValueBacking;
            public ThenEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesArrayValueBacking = default;
            }
            public ThenEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> value)
            {
                this._menesArrayValueBacking = value;
                this._menesJsonElementBacking = default;
            }
            public static implicit operator ThenEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> items)
            {
                return new RootEntity.ThenEntity(items);
            }
            /// <inheritdoc />
            public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
            /// <inheritdoc />
            public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
            /// <inheritdoc />
            public bool IsNumber => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number;
            /// <inheritdoc />
            public bool IsInteger => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number;
            /// <inheritdoc />
            public bool IsString => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.String;
            /// <inheritdoc />
            public bool IsObject => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object;
            /// <inheritdoc />
            public bool IsBoolean => this.HasJsonElement && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.True || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.False);
            /// <inheritdoc />
            public bool IsArray => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Array;
            /// <inheritdoc />
            public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            /// <inheritdoc />
            public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
            /// <inheritdoc />
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
                if (level != Menes.ValidationLevel.Flag)
                {
                    result = result.UsingStack();
                }
                if (this.IsArray)
                {
                    int arrayLength = 0;
                    var arrayEnumerator = this.EnumerateArray();
                    while (arrayEnumerator.MoveNext())
                    {
                        switch (arrayLength)
                        {
                            case 0:
                                result = arrayEnumerator.Current.As<Menes.JsonAny>().Validate(result, level);
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
                                result = result.WithLocalItemIndex(arrayLength);
                                break;
                            case 1:
                                result = arrayEnumerator.Current.As<Menes.JsonAny>().Validate(result, level);
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
                                result = result.WithLocalItemIndex(arrayLength);
                                break;
                            case 2:
                                result = arrayEnumerator.Current.As<RootEntity.ThenEntity.Items2Entity>().Validate(result, level);
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
                                result = result.WithLocalItemIndex(arrayLength);
                                break;
                            default:
                                break;
                        }
                        arrayLength++;
                    }
                }
                return result;
            }
            /// <inheritdoc />
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                    return;
                }
                writer.WriteStartArray();
                foreach (var item in this._menesArrayValueBacking)
                {
                    item.WriteTo(writer);
                }
                writer.WriteEndArray();
            }
            /// <inheritdoc />
            public T As<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(ThenEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<ThenEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.ThenEntity))
                {
                    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(in T other)
                where T : struct, Menes.IJsonValue
            {
                return false;
            }
            public RootEntity.ThenEntity.MenesArrayEnumerator GetEnumerator()
            {
                return new RootEntity.ThenEntity.MenesArrayEnumerator(this);
            }
            public RootEntity.ThenEntity.MenesArrayEnumerator EnumerateArray()
            {
                return new RootEntity.ThenEntity.MenesArrayEnumerator(this);
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            /// <inheritdoc />
            public int GetArrayLength()
            {
                if (this.HasJsonElement)
                {
                    return this.JsonElement.GetArrayLength();
                }
                return this._menesArrayValueBacking?.Length ?? 0;
            }
            /// <inheritdoc />
            public T GetItemAtIndex<T>(int index)
                where T : struct, Menes.IJsonValue
            {
                if (this.HasJsonElement)
                {
                    int currentIndex = 0;
                    foreach (var item in this.JsonElement.EnumerateArray())
                    {
                        if (currentIndex == index)
                        {
                            return Menes.JsonValue.As<T>(item);
                        }
                    }
                    throw new System.IndexOutOfRangeException();
                }
                if (this._menesArrayValueBacking is not null)
                {
                    return this._menesArrayValueBacking.Value[index].As<T>();
                }
                return default;
            }
            public ThenEntity Add<T1>(T1 item1)
                where T1 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                return new RootEntity.ThenEntity(arrayBuilder.ToImmutable());
            }
            public ThenEntity Add<T1, T2>(T1 item1, T2 item2)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                arrayBuilder.Add(item2.As<Menes.JsonAny>());
                return new RootEntity.ThenEntity(arrayBuilder.ToImmutable());
            }
            public ThenEntity Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                arrayBuilder.Add(item2.As<Menes.JsonAny>());
                arrayBuilder.Add(item3.As<Menes.JsonAny>());
                return new RootEntity.ThenEntity(arrayBuilder.ToImmutable());
            }
            public ThenEntity Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
                where T4 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                arrayBuilder.Add(item2.As<Menes.JsonAny>());
                arrayBuilder.Add(item3.As<Menes.JsonAny>());
                arrayBuilder.Add(item4.As<Menes.JsonAny>());
                return new RootEntity.ThenEntity(arrayBuilder.ToImmutable());
            }
            public ThenEntity Add<T>(params T[] items)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                foreach (var item1 in items)
                {
                    arrayBuilder.Add(item1.As<Menes.JsonAny>());
                }
                return new RootEntity.ThenEntity(arrayBuilder.ToImmutable());
            }
            public ThenEntity Insert<T>(int index, T item1)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ThenEntity(arrayBuilder.ToImmutable());
            }
            public ThenEntity Insert<T1, T2>(int index, T1 item1, T2 item2)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        arrayBuilder.Add(item2.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ThenEntity(arrayBuilder.ToImmutable());
            }
            public ThenEntity Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        arrayBuilder.Add(item2.As<Menes.JsonAny>());
                        arrayBuilder.Add(item3.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ThenEntity(arrayBuilder.ToImmutable());
            }
            public ThenEntity Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
                where T4 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        arrayBuilder.Add(item2.As<Menes.JsonAny>());
                        arrayBuilder.Add(item3.As<Menes.JsonAny>());
                        arrayBuilder.Add(item4.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ThenEntity(arrayBuilder.ToImmutable());
            }
            public ThenEntity Insert<T>(int index, params T[] items)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        foreach (var item1 in items)
                        {
                            arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        }
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ThenEntity(arrayBuilder.ToImmutable());
            }
            public ThenEntity RemoveAt(int index)
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool removed = false;
                foreach (var item in this._menesArrayValueBacking)
                {
                    if (currentIndex != index)
                    {
                        arrayBuilder.Add(item);
                    }
                    else
                    {
                        removed = true;
                    }
                    currentIndex++;
                }
                if (!removed)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ThenEntity(arrayBuilder.ToImmutable());
            }
            public ThenEntity RemoveIf(System.Predicate<Menes.JsonAny> condition)
            {
                return this.RemoveIf<Menes.JsonAny>(condition);
            }
            public ThenEntity RemoveIf<T>(System.Predicate<T> condition)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var item in this._menesArrayValueBacking)
                {
                    if (!condition(item.As<T>()))
                    {
                        arrayBuilder.Add(item);
                    }
                }
                return new RootEntity.ThenEntity(arrayBuilder.ToImmutable());
            }
            private bool AllBackingFieldsAreNull()
            {
                if (this._menesArrayValueBacking is not null)
                {
                    return false;
                }
                return true;
            }
            public readonly struct Items2Entity : Menes.IJsonValue
            {
                public static readonly Items2Entity Null = default(Items2Entity);
                private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
                private readonly Menes.JsonString? _menesStringTypeBacking;
                private static readonly Menes.JsonString _MenesConstValue = new Menes.JsonString("then");
                public Items2Entity(System.Text.Json.JsonElement jsonElement)
                {
                    this._menesJsonElementBacking = jsonElement;
                    this._menesStringTypeBacking = default;
                }
                public Items2Entity(Menes.JsonString value)
                {
                    this._menesJsonElementBacking = default;
                    this._menesStringTypeBacking = value;
                }
                private Items2Entity(Menes.JsonString? _menesStringTypeBacking)
                {
                    this._menesJsonElementBacking = default;
                    this._menesStringTypeBacking = _menesStringTypeBacking;
                }
                public static implicit operator Menes.JsonString(Items2Entity value)
                {
                    return value.As<Menes.JsonString>();
                }
                public static implicit operator Items2Entity(Menes.JsonString value)
                {
                    return value.As<RootEntity.ThenEntity.Items2Entity>();
                }
                public static implicit operator string(Items2Entity value)
                {
                    return (string)(Menes.JsonString)value;
                }
                public static implicit operator Items2Entity(string value)
                {
                    return (RootEntity.ThenEntity.Items2Entity)(Menes.JsonString)value;
                }
                /// <inheritdoc />
                public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
                /// <inheritdoc />
                public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
                /// <inheritdoc />
                public bool IsNumber => false;
                /// <inheritdoc />
                public bool IsInteger => false;
                /// <inheritdoc />
                public bool IsString => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.String) || (!this.HasJsonElement && this._menesStringTypeBacking is not null);
                /// <inheritdoc />
                public bool IsObject => false;
                /// <inheritdoc />
                public bool IsBoolean => false;
                /// <inheritdoc />
                public bool IsArray => false;
                /// <inheritdoc />
                public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
                /// <inheritdoc />
                public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
                /// <inheritdoc />
                public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
                {
                    Menes.ValidationContext result = validationContext;
                    if (level != Menes.ValidationLevel.Flag)
                    {
                        result = result.UsingStack();
                    }
                    if (!this.IsString)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of string");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                    }
                    if (!this.IsString)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"then\"");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                    }
                    else
                    {
                        if (!System.MemoryExtensions.SequenceEqual(this.As<Menes.JsonString>().AsSpan(), _MenesConstValue.AsSpan()))
                        {
                            if (level >= Menes.ValidationLevel.Basic)
                            {
                                result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"then\"");
                            }
                            else
                            {
                                result = result.WithResult(isValid: false);
                            }
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                            {
                                return result;
                            }
                        }
                        else
                        {
                            if (level == Menes.ValidationLevel.Verbose)
                            {
                                result = result.WithResult(isValid: true);
                            }
                        }
                    }
                    return result;
                }
                /// <inheritdoc />
                public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
                {
                    if (this.HasJsonElement)
                    {
                        this.JsonElement.WriteTo(writer);
                        return;
                    }
                    this._menesStringTypeBacking?.WriteTo(writer);
                }
                /// <inheritdoc />
                public T As<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(Items2Entity))
                    {
                        return Corvus.Extensions.CastTo<T>.From(this);
                    }
                    return Menes.JsonValue.As<Items2Entity, T>(this);
                }
                /// <inheritdoc />
                public bool Is<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(RootEntity.ThenEntity.Items2Entity))
                    {
                        return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                    }
                    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                /// <inheritdoc/>
                public bool Equals<T>(in T other)
                    where T : struct, Menes.IJsonValue
                {
                    if (!other.IsString)
                    {
                        return false;
                    }
                    return ((Menes.JsonString)this).Equals(other);
                }
                private bool AllBackingFieldsAreNull()
                {
                    if (this._menesStringTypeBacking is not null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            /// <summary>
            /// An enumerator for the array values in a <see cref="ThenEntity"/>.
            /// </summary>
            public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonAny>, System.Collections.IEnumerator
            {
                private ThenEntity instance;
                private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                internal MenesArrayEnumerator(ThenEntity instance)
                {
                    this.instance = instance;
                    if (this.instance.HasJsonElement)
                    {
                        this.index = -2;
                        this.hasJsonEnumerator = true;
                        this.jsonEnumerator = this.instance.JsonElement.EnumerateArray();
                    }
                    else
                    {
                        this.index = -1;
                        this.hasJsonEnumerator = false;
                        this.jsonEnumerator = default;
                    }
                }
                /// <inheritdoc/>
                public Menes.JsonAny Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.JsonAny(this.jsonEnumerator.Current);
                        }
                        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonAny> array && this.index >= 0 && this.index < array.Length)
                        {
                            return array[this.index];
                        }
                        return default;
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the array values in a <see cref="ThenEntity"/>.</returns>
                public MenesArrayEnumerator GetEnumerator()
                {
                    MenesArrayEnumerator result = this;
                    result.Reset();
                    return result;
                }
                /// <inheritdoc/>
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                /// <inheritdoc/>
                System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                /// <inheritdoc/>
                public void Dispose()
                {
                    if (this.hasJsonEnumerator)
                    {
                        this.jsonEnumerator.Dispose();
                    }
                }
                /// <inheritdoc/>
                public void Reset()
                {
                    if (this.hasJsonEnumerator)
                    {
                        this.jsonEnumerator.Reset();
                    }
                    else
                    {
                        this.index = -1;
                    }
                }
                /// <inheritdoc/>
                public bool MoveNext()
                {
                    if (this.hasJsonEnumerator)
                    {
                        return this.jsonEnumerator.MoveNext();
                    }
                    else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonAny> array && this.index + 1 < array.Length)
                    {
                        this.index++;
                        return true;
                    }
                    return false;
                }
            }
        }
        public readonly struct ElseEntity : Menes.IJsonValue, Menes.IJsonArray<ElseEntity, Menes.JsonAny>
        {
            public static readonly ElseEntity Null = default(ElseEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? _menesArrayValueBacking;
            public ElseEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesArrayValueBacking = default;
            }
            public ElseEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> value)
            {
                this._menesArrayValueBacking = value;
                this._menesJsonElementBacking = default;
            }
            public static implicit operator ElseEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> items)
            {
                return new RootEntity.ElseEntity(items);
            }
            /// <inheritdoc />
            public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
            /// <inheritdoc />
            public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
            /// <inheritdoc />
            public bool IsNumber => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number;
            /// <inheritdoc />
            public bool IsInteger => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number;
            /// <inheritdoc />
            public bool IsString => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.String;
            /// <inheritdoc />
            public bool IsObject => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object;
            /// <inheritdoc />
            public bool IsBoolean => this.HasJsonElement && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.True || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.False);
            /// <inheritdoc />
            public bool IsArray => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Array;
            /// <inheritdoc />
            public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            /// <inheritdoc />
            public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
            /// <inheritdoc />
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
                if (level != Menes.ValidationLevel.Flag)
                {
                    result = result.UsingStack();
                }
                if (this.IsArray)
                {
                    int arrayLength = 0;
                    var arrayEnumerator = this.EnumerateArray();
                    while (arrayEnumerator.MoveNext())
                    {
                        switch (arrayLength)
                        {
                            case 0:
                                result = arrayEnumerator.Current.As<Menes.JsonAny>().Validate(result, level);
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
                                result = result.WithLocalItemIndex(arrayLength);
                                break;
                            case 1:
                                result = arrayEnumerator.Current.As<Menes.JsonAny>().Validate(result, level);
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
                                result = result.WithLocalItemIndex(arrayLength);
                                break;
                            case 2:
                                result = arrayEnumerator.Current.As<Menes.JsonAny>().Validate(result, level);
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
                                result = result.WithLocalItemIndex(arrayLength);
                                break;
                            case 3:
                                result = arrayEnumerator.Current.As<RootEntity.ElseEntity.Items3Entity>().Validate(result, level);
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
                                result = result.WithLocalItemIndex(arrayLength);
                                break;
                            default:
                                break;
                        }
                        arrayLength++;
                    }
                }
                return result;
            }
            /// <inheritdoc />
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                    return;
                }
                writer.WriteStartArray();
                foreach (var item in this._menesArrayValueBacking)
                {
                    item.WriteTo(writer);
                }
                writer.WriteEndArray();
            }
            /// <inheritdoc />
            public T As<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(ElseEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<ElseEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.ElseEntity))
                {
                    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(in T other)
                where T : struct, Menes.IJsonValue
            {
                return false;
            }
            public RootEntity.ElseEntity.MenesArrayEnumerator GetEnumerator()
            {
                return new RootEntity.ElseEntity.MenesArrayEnumerator(this);
            }
            public RootEntity.ElseEntity.MenesArrayEnumerator EnumerateArray()
            {
                return new RootEntity.ElseEntity.MenesArrayEnumerator(this);
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            /// <inheritdoc />
            public int GetArrayLength()
            {
                if (this.HasJsonElement)
                {
                    return this.JsonElement.GetArrayLength();
                }
                return this._menesArrayValueBacking?.Length ?? 0;
            }
            /// <inheritdoc />
            public T GetItemAtIndex<T>(int index)
                where T : struct, Menes.IJsonValue
            {
                if (this.HasJsonElement)
                {
                    int currentIndex = 0;
                    foreach (var item in this.JsonElement.EnumerateArray())
                    {
                        if (currentIndex == index)
                        {
                            return Menes.JsonValue.As<T>(item);
                        }
                    }
                    throw new System.IndexOutOfRangeException();
                }
                if (this._menesArrayValueBacking is not null)
                {
                    return this._menesArrayValueBacking.Value[index].As<T>();
                }
                return default;
            }
            public ElseEntity Add<T1>(T1 item1)
                where T1 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                return new RootEntity.ElseEntity(arrayBuilder.ToImmutable());
            }
            public ElseEntity Add<T1, T2>(T1 item1, T2 item2)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                arrayBuilder.Add(item2.As<Menes.JsonAny>());
                return new RootEntity.ElseEntity(arrayBuilder.ToImmutable());
            }
            public ElseEntity Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                arrayBuilder.Add(item2.As<Menes.JsonAny>());
                arrayBuilder.Add(item3.As<Menes.JsonAny>());
                return new RootEntity.ElseEntity(arrayBuilder.ToImmutable());
            }
            public ElseEntity Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
                where T4 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                arrayBuilder.Add(item2.As<Menes.JsonAny>());
                arrayBuilder.Add(item3.As<Menes.JsonAny>());
                arrayBuilder.Add(item4.As<Menes.JsonAny>());
                return new RootEntity.ElseEntity(arrayBuilder.ToImmutable());
            }
            public ElseEntity Add<T>(params T[] items)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                foreach (var item1 in items)
                {
                    arrayBuilder.Add(item1.As<Menes.JsonAny>());
                }
                return new RootEntity.ElseEntity(arrayBuilder.ToImmutable());
            }
            public ElseEntity Insert<T>(int index, T item1)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ElseEntity(arrayBuilder.ToImmutable());
            }
            public ElseEntity Insert<T1, T2>(int index, T1 item1, T2 item2)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        arrayBuilder.Add(item2.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ElseEntity(arrayBuilder.ToImmutable());
            }
            public ElseEntity Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        arrayBuilder.Add(item2.As<Menes.JsonAny>());
                        arrayBuilder.Add(item3.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ElseEntity(arrayBuilder.ToImmutable());
            }
            public ElseEntity Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
                where T4 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        arrayBuilder.Add(item2.As<Menes.JsonAny>());
                        arrayBuilder.Add(item3.As<Menes.JsonAny>());
                        arrayBuilder.Add(item4.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ElseEntity(arrayBuilder.ToImmutable());
            }
            public ElseEntity Insert<T>(int index, params T[] items)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        foreach (var item1 in items)
                        {
                            arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        }
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ElseEntity(arrayBuilder.ToImmutable());
            }
            public ElseEntity RemoveAt(int index)
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool removed = false;
                foreach (var item in this._menesArrayValueBacking)
                {
                    if (currentIndex != index)
                    {
                        arrayBuilder.Add(item);
                    }
                    else
                    {
                        removed = true;
                    }
                    currentIndex++;
                }
                if (!removed)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ElseEntity(arrayBuilder.ToImmutable());
            }
            public ElseEntity RemoveIf(System.Predicate<Menes.JsonAny> condition)
            {
                return this.RemoveIf<Menes.JsonAny>(condition);
            }
            public ElseEntity RemoveIf<T>(System.Predicate<T> condition)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var item in this._menesArrayValueBacking)
                {
                    if (!condition(item.As<T>()))
                    {
                        arrayBuilder.Add(item);
                    }
                }
                return new RootEntity.ElseEntity(arrayBuilder.ToImmutable());
            }
            private bool AllBackingFieldsAreNull()
            {
                if (this._menesArrayValueBacking is not null)
                {
                    return false;
                }
                return true;
            }
            public readonly struct Items3Entity : Menes.IJsonValue
            {
                public static readonly Items3Entity Null = default(Items3Entity);
                private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
                private readonly Menes.JsonString? _menesStringTypeBacking;
                private static readonly Menes.JsonString _MenesConstValue = new Menes.JsonString("else");
                public Items3Entity(System.Text.Json.JsonElement jsonElement)
                {
                    this._menesJsonElementBacking = jsonElement;
                    this._menesStringTypeBacking = default;
                }
                public Items3Entity(Menes.JsonString value)
                {
                    this._menesJsonElementBacking = default;
                    this._menesStringTypeBacking = value;
                }
                private Items3Entity(Menes.JsonString? _menesStringTypeBacking)
                {
                    this._menesJsonElementBacking = default;
                    this._menesStringTypeBacking = _menesStringTypeBacking;
                }
                public static implicit operator Menes.JsonString(Items3Entity value)
                {
                    return value.As<Menes.JsonString>();
                }
                public static implicit operator Items3Entity(Menes.JsonString value)
                {
                    return value.As<RootEntity.ElseEntity.Items3Entity>();
                }
                public static implicit operator string(Items3Entity value)
                {
                    return (string)(Menes.JsonString)value;
                }
                public static implicit operator Items3Entity(string value)
                {
                    return (RootEntity.ElseEntity.Items3Entity)(Menes.JsonString)value;
                }
                /// <inheritdoc />
                public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
                /// <inheritdoc />
                public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
                /// <inheritdoc />
                public bool IsNumber => false;
                /// <inheritdoc />
                public bool IsInteger => false;
                /// <inheritdoc />
                public bool IsString => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.String) || (!this.HasJsonElement && this._menesStringTypeBacking is not null);
                /// <inheritdoc />
                public bool IsObject => false;
                /// <inheritdoc />
                public bool IsBoolean => false;
                /// <inheritdoc />
                public bool IsArray => false;
                /// <inheritdoc />
                public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
                /// <inheritdoc />
                public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
                /// <inheritdoc />
                public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
                {
                    Menes.ValidationContext result = validationContext;
                    if (level != Menes.ValidationLevel.Flag)
                    {
                        result = result.UsingStack();
                    }
                    if (!this.IsString)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of string");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                    }
                    if (!this.IsString)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"else\"");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                    }
                    else
                    {
                        if (!System.MemoryExtensions.SequenceEqual(this.As<Menes.JsonString>().AsSpan(), _MenesConstValue.AsSpan()))
                        {
                            if (level >= Menes.ValidationLevel.Basic)
                            {
                                result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"else\"");
                            }
                            else
                            {
                                result = result.WithResult(isValid: false);
                            }
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                            {
                                return result;
                            }
                        }
                        else
                        {
                            if (level == Menes.ValidationLevel.Verbose)
                            {
                                result = result.WithResult(isValid: true);
                            }
                        }
                    }
                    return result;
                }
                /// <inheritdoc />
                public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
                {
                    if (this.HasJsonElement)
                    {
                        this.JsonElement.WriteTo(writer);
                        return;
                    }
                    this._menesStringTypeBacking?.WriteTo(writer);
                }
                /// <inheritdoc />
                public T As<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(Items3Entity))
                    {
                        return Corvus.Extensions.CastTo<T>.From(this);
                    }
                    return Menes.JsonValue.As<Items3Entity, T>(this);
                }
                /// <inheritdoc />
                public bool Is<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(RootEntity.ElseEntity.Items3Entity))
                    {
                        return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                    }
                    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                /// <inheritdoc/>
                public bool Equals<T>(in T other)
                    where T : struct, Menes.IJsonValue
                {
                    if (!other.IsString)
                    {
                        return false;
                    }
                    return ((Menes.JsonString)this).Equals(other);
                }
                private bool AllBackingFieldsAreNull()
                {
                    if (this._menesStringTypeBacking is not null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            /// <summary>
            /// An enumerator for the array values in a <see cref="ElseEntity"/>.
            /// </summary>
            public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonAny>, System.Collections.IEnumerator
            {
                private ElseEntity instance;
                private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                internal MenesArrayEnumerator(ElseEntity instance)
                {
                    this.instance = instance;
                    if (this.instance.HasJsonElement)
                    {
                        this.index = -2;
                        this.hasJsonEnumerator = true;
                        this.jsonEnumerator = this.instance.JsonElement.EnumerateArray();
                    }
                    else
                    {
                        this.index = -1;
                        this.hasJsonEnumerator = false;
                        this.jsonEnumerator = default;
                    }
                }
                /// <inheritdoc/>
                public Menes.JsonAny Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.JsonAny(this.jsonEnumerator.Current);
                        }
                        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonAny> array && this.index >= 0 && this.index < array.Length)
                        {
                            return array[this.index];
                        }
                        return default;
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the array values in a <see cref="ElseEntity"/>.</returns>
                public MenesArrayEnumerator GetEnumerator()
                {
                    MenesArrayEnumerator result = this;
                    result.Reset();
                    return result;
                }
                /// <inheritdoc/>
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                /// <inheritdoc/>
                System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                /// <inheritdoc/>
                public void Dispose()
                {
                    if (this.hasJsonEnumerator)
                    {
                        this.jsonEnumerator.Dispose();
                    }
                }
                /// <inheritdoc/>
                public void Reset()
                {
                    if (this.hasJsonEnumerator)
                    {
                        this.jsonEnumerator.Reset();
                    }
                    else
                    {
                        this.index = -1;
                    }
                }
                /// <inheritdoc/>
                public bool MoveNext()
                {
                    if (this.hasJsonEnumerator)
                    {
                        return this.jsonEnumerator.MoveNext();
                    }
                    else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonAny> array && this.index + 1 < array.Length)
                    {
                        this.index++;
                        return true;
                    }
                    return false;
                }
            }
        }
        public readonly struct Items0Entity : Menes.IJsonValue
        {
            public static readonly Items0Entity Null = default(Items0Entity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonString? _menesStringTypeBacking;
            private static readonly Menes.JsonString _MenesConstValue = new Menes.JsonString("foo");
            public Items0Entity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesStringTypeBacking = default;
            }
            public Items0Entity(Menes.JsonString value)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = value;
            }
            private Items0Entity(Menes.JsonString? _menesStringTypeBacking)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = _menesStringTypeBacking;
            }
            public static implicit operator Menes.JsonString(Items0Entity value)
            {
                return value.As<Menes.JsonString>();
            }
            public static implicit operator Items0Entity(Menes.JsonString value)
            {
                return value.As<RootEntity.Items0Entity>();
            }
            public static implicit operator string(Items0Entity value)
            {
                return (string)(Menes.JsonString)value;
            }
            public static implicit operator Items0Entity(string value)
            {
                return (RootEntity.Items0Entity)(Menes.JsonString)value;
            }
            /// <inheritdoc />
            public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
            /// <inheritdoc />
            public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
            /// <inheritdoc />
            public bool IsNumber => false;
            /// <inheritdoc />
            public bool IsInteger => false;
            /// <inheritdoc />
            public bool IsString => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.String) || (!this.HasJsonElement && this._menesStringTypeBacking is not null);
            /// <inheritdoc />
            public bool IsObject => false;
            /// <inheritdoc />
            public bool IsBoolean => false;
            /// <inheritdoc />
            public bool IsArray => false;
            /// <inheritdoc />
            public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            /// <inheritdoc />
            public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
            /// <inheritdoc />
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
                if (level != Menes.ValidationLevel.Flag)
                {
                    result = result.UsingStack();
                }
                if (!this.IsString)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of string");
                    }
                    else
                    {
                        result = result.WithResult(isValid: false);
                    }
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                if (!this.IsString)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"foo\"");
                    }
                    else
                    {
                        result = result.WithResult(isValid: false);
                    }
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (!System.MemoryExtensions.SequenceEqual(this.As<Menes.JsonString>().AsSpan(), _MenesConstValue.AsSpan()))
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"foo\"");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                    }
                    else
                    {
                        if (level == Menes.ValidationLevel.Verbose)
                        {
                            result = result.WithResult(isValid: true);
                        }
                    }
                }
                return result;
            }
            /// <inheritdoc />
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                    return;
                }
                this._menesStringTypeBacking?.WriteTo(writer);
            }
            /// <inheritdoc />
            public T As<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Items0Entity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<Items0Entity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.Items0Entity))
                {
                    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(in T other)
                where T : struct, Menes.IJsonValue
            {
                if (!other.IsString)
                {
                    return false;
                }
                return ((Menes.JsonString)this).Equals(other);
            }
            private bool AllBackingFieldsAreNull()
            {
                if (this._menesStringTypeBacking is not null)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// An enumerator for the array values in a <see cref="RootEntity"/>.
        /// </summary>
        public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonAny>, System.Collections.IEnumerator
        {
            private RootEntity instance;
            private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
            private bool hasJsonEnumerator;
            private int index;
            internal MenesArrayEnumerator(RootEntity instance)
            {
                this.instance = instance;
                if (this.instance.HasJsonElement)
                {
                    this.index = -2;
                    this.hasJsonEnumerator = true;
                    this.jsonEnumerator = this.instance.JsonElement.EnumerateArray();
                }
                else
                {
                    this.index = -1;
                    this.hasJsonEnumerator = false;
                    this.jsonEnumerator = default;
                }
            }
            /// <inheritdoc/>
            public Menes.JsonAny Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new Menes.JsonAny(this.jsonEnumerator.Current);
                    }
                    else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonAny> array && this.index >= 0 && this.index < array.Length)
                    {
                        return array[this.index];
                    }
                    return default;
                }
            }
            /// <inheritdoc/>
            object System.Collections.IEnumerator.Current => this.Current;
            /// <summary>
            /// Returns a fresh copy of the enumerator
            /// </summary>
            /// <returns>An enumerator for the array values in a <see cref="RootEntity"/>.</returns>
            public MenesArrayEnumerator GetEnumerator()
            {
                MenesArrayEnumerator result = this;
                result.Reset();
                return result;
            }
            /// <inheritdoc/>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            /// <inheritdoc/>
            System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            /// <inheritdoc/>
            public void Dispose()
            {
                if (this.hasJsonEnumerator)
                {
                    this.jsonEnumerator.Dispose();
                }
            }
            /// <inheritdoc/>
            public void Reset()
            {
                if (this.hasJsonEnumerator)
                {
                    this.jsonEnumerator.Reset();
                }
                else
                {
                    this.index = -1;
                }
            }
            /// <inheritdoc/>
            public bool MoveNext()
            {
                if (this.hasJsonEnumerator)
                {
                    return this.jsonEnumerator.MoveNext();
                }
                else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonAny> array && this.index + 1 < array.Length)
                {
                    this.index++;
                    return true;
                }
                return false;
            }
        }
    }
}
