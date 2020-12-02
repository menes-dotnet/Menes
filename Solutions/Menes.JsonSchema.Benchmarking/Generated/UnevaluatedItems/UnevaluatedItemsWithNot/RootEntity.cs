// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace UnevaluatedItemsFeature.UnevaluatedItemsWithNot
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
            result = ValidateNot(this, result, level);
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
            Menes.ValidationContext ValidateNot(in RootEntity that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
                var notValue = that.AsNotEntity();
                Menes.ValidationContext notResult;
                if (level == Menes.ValidationLevel.Flag)
                {
                    notResult = notValue.Validate(validationContext.CreateChildContext(), level);
                }
                else
                {
                    notResult = notValue.Validate(validationContext.CreateChildContext("#/not"), level);
                }
                if (level == Menes.ValidationLevel.Flag && !notResult.IsValid)
                {
                    return result;
                }
                if (notResult.IsValid)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "9.2.1.4. not");
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
        public readonly RootEntity.NotEntity AsNotEntity()
        {
            return this.As<RootEntity.NotEntity>();
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
        public readonly struct NotEntity : Menes.IJsonValue
        {
            public static readonly NotEntity Null = default(NotEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            public NotEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
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
                result = ValidateNot(this, result, level);
                return result;
                Menes.ValidationContext ValidateNot(in RootEntity.NotEntity that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
                {
                    Menes.ValidationContext result = validationContext;
                    var notValue = that.AsNot0();
                    Menes.ValidationContext notResult;
                    if (level == Menes.ValidationLevel.Flag)
                    {
                        notResult = notValue.Validate(validationContext.CreateChildContext(), level);
                    }
                    else
                    {
                        notResult = notValue.Validate(validationContext.CreateChildContext("#/not/not"), level);
                    }
                    if (level == Menes.ValidationLevel.Flag && !notResult.IsValid)
                    {
                        return result;
                    }
                    if (notResult.IsValid)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "9.2.1.4. not");
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
            }
            /// <inheritdoc />
            public T As<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(NotEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<NotEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.NotEntity))
                {
                    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
            }
            public readonly RootEntity.NotEntity.Not0 AsNot0()
            {
                return this.As<RootEntity.NotEntity.Not0>();
            }
            /// <inheritdoc/>
            public bool Equals<T>(in T other)
                where T : struct, Menes.IJsonValue
            {
                return false;
            }
            private bool AllBackingFieldsAreNull()
            {
                return true;
            }
            public readonly struct Not0 : Menes.IJsonValue, Menes.IJsonArray<Not0, Menes.JsonAny>
            {
                public static readonly Not0 Null = default(Not0);
                private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
                private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? _menesArrayValueBacking;
                public Not0(System.Text.Json.JsonElement jsonElement)
                {
                    this._menesJsonElementBacking = jsonElement;
                    this._menesArrayValueBacking = default;
                }
                public Not0(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> value)
                {
                    this._menesArrayValueBacking = value;
                    this._menesJsonElementBacking = default;
                }
                public static implicit operator Not0(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> items)
                {
                    return new RootEntity.NotEntity.Not0(items);
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
                                    result = arrayEnumerator.Current.As<RootEntity.NotEntity.Not0.Items1Entity>().Validate(result, level);
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
                    if (typeof(T) == typeof(Not0))
                    {
                        return Corvus.Extensions.CastTo<T>.From(this);
                    }
                    return Menes.JsonValue.As<Not0, T>(this);
                }
                /// <inheritdoc />
                public bool Is<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(RootEntity.NotEntity.Not0))
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
                public RootEntity.NotEntity.Not0.MenesArrayEnumerator GetEnumerator()
                {
                    return new RootEntity.NotEntity.Not0.MenesArrayEnumerator(this);
                }
                public RootEntity.NotEntity.Not0.MenesArrayEnumerator EnumerateArray()
                {
                    return new RootEntity.NotEntity.Not0.MenesArrayEnumerator(this);
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
                public Not0 Add<T1>(T1 item1)
                    where T1 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        arrayBuilder.Add(oldItem);
                    }
                    arrayBuilder.Add(item1.As<Menes.JsonAny>());
                    return new RootEntity.NotEntity.Not0(arrayBuilder.ToImmutable());
                }
                public Not0 Add<T1, T2>(T1 item1, T2 item2)
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
                    return new RootEntity.NotEntity.Not0(arrayBuilder.ToImmutable());
                }
                public Not0 Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
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
                    return new RootEntity.NotEntity.Not0(arrayBuilder.ToImmutable());
                }
                public Not0 Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
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
                    return new RootEntity.NotEntity.Not0(arrayBuilder.ToImmutable());
                }
                public Not0 Add<T>(params T[] items)
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
                    return new RootEntity.NotEntity.Not0(arrayBuilder.ToImmutable());
                }
                public Not0 Insert<T>(int index, T item1)
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
                    return new RootEntity.NotEntity.Not0(arrayBuilder.ToImmutable());
                }
                public Not0 Insert<T1, T2>(int index, T1 item1, T2 item2)
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
                    return new RootEntity.NotEntity.Not0(arrayBuilder.ToImmutable());
                }
                public Not0 Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
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
                    return new RootEntity.NotEntity.Not0(arrayBuilder.ToImmutable());
                }
                public Not0 Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
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
                    return new RootEntity.NotEntity.Not0(arrayBuilder.ToImmutable());
                }
                public Not0 Insert<T>(int index, params T[] items)
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
                    return new RootEntity.NotEntity.Not0(arrayBuilder.ToImmutable());
                }
                public Not0 RemoveAt(int index)
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
                    return new RootEntity.NotEntity.Not0(arrayBuilder.ToImmutable());
                }
                public Not0 RemoveIf(System.Predicate<Menes.JsonAny> condition)
                {
                    return this.RemoveIf<Menes.JsonAny>(condition);
                }
                public Not0 RemoveIf<T>(System.Predicate<T> condition)
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
                    return new RootEntity.NotEntity.Not0(arrayBuilder.ToImmutable());
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
                        return value.As<RootEntity.NotEntity.Not0.Items1Entity>();
                    }
                    public static implicit operator string(Items1Entity value)
                    {
                        return (string)(Menes.JsonString)value;
                    }
                    public static implicit operator Items1Entity(string value)
                    {
                        return (RootEntity.NotEntity.Not0.Items1Entity)(Menes.JsonString)value;
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
                        if (typeof(T) == typeof(RootEntity.NotEntity.Not0.Items1Entity))
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
                /// An enumerator for the array values in a <see cref="Not0"/>.
                /// </summary>
                public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonAny>, System.Collections.IEnumerator
                {
                    private Not0 instance;
                    private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                    private bool hasJsonEnumerator;
                    private int index;
                    internal MenesArrayEnumerator(Not0 instance)
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
                    /// <returns>An enumerator for the array values in a <see cref="Not0"/>.</returns>
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
