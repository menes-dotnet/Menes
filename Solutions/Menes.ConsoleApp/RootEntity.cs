// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Driver.GeneratedTypes
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
        public static implicit operator RootEntity.AnyOf0Entity(RootEntity value)
        {
            return value.As<RootEntity.AnyOf0Entity>();
        }
        public static implicit operator RootEntity(RootEntity.AnyOf0Entity value)
        {
            return value.As<RootEntity>();
        }
        public static implicit operator RootEntity.AnyOf1Entity(RootEntity value)
        {
            return value.As<RootEntity.AnyOf1Entity>();
        }
        public static implicit operator RootEntity(RootEntity.AnyOf1Entity value)
        {
            return value.As<RootEntity>();
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
        public Menes.ValidationContext Validate(Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
        {
            Menes.ValidationContext result = validationContext;
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
            result = ValidateAnyOf(this, result, level);
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
                            }
                            break;
                    }
                    arrayLength++;
                }
            }
            return result;
            Menes.ValidationContext ValidateAnyOf(in RootEntity that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
                var anyOf0 = that.AsAnyOf0Entity();
                Menes.ValidationContext anyOfResult0;
                if (level == Menes.ValidationLevel.Flag)
                {
                    anyOfResult0 = anyOf0.Validate(validationContext.CreateChildContext(), level);
                }
                else
                {
                    anyOfResult0 = anyOf0.Validate(validationContext.CreateChildContext("#/anyOf/0"), level);
                }
                if (level == Menes.ValidationLevel.Flag && anyOfResult0.IsValid)
                {
                    result = result.MergeChildContext(anyOfResult0, false);
                    return result;
                }
                if (anyOfResult0.IsValid)
                {
                    result = result.MergeChildContext(anyOfResult0, false);
                }
                var anyOf1 = that.AsAnyOf1Entity();
                Menes.ValidationContext anyOfResult1;
                if (level == Menes.ValidationLevel.Flag)
                {
                    anyOfResult1 = anyOf1.Validate(validationContext.CreateChildContext(), level);
                }
                else
                {
                    anyOfResult1 = anyOf1.Validate(validationContext.CreateChildContext("#/anyOf/1"), level);
                }
                if (level == Menes.ValidationLevel.Flag && anyOfResult1.IsValid)
                {
                    result = result.MergeChildContext(anyOfResult1, false);
                    return result;
                }
                if (anyOfResult1.IsValid)
                {
                    result = result.MergeChildContext(anyOfResult1, false);
                }
                if (!anyOfResult0.IsValid && !anyOfResult1.IsValid)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "9.2.1.2. anyOf");
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
        public readonly RootEntity.AnyOf0Entity AsAnyOf0Entity()
        {
            return this.As<RootEntity.AnyOf0Entity>();
        }
        public readonly RootEntity.AnyOf1Entity AsAnyOf1Entity()
        {
            return this.As<RootEntity.AnyOf1Entity>();
        }
        /// <inheritdoc/>
        public bool Equals<T>(T other)
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
        public readonly struct AnyOf0Entity : Menes.IJsonValue, Menes.IJsonArray<AnyOf0Entity, Menes.JsonAny>
        {
            public static readonly AnyOf0Entity Null = default(AnyOf0Entity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? _menesArrayValueBacking;
            public AnyOf0Entity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesArrayValueBacking = default;
            }
            public AnyOf0Entity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> value)
            {
                this._menesArrayValueBacking = value;
                this._menesJsonElementBacking = default;
            }
            public static implicit operator AnyOf0Entity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> items)
            {
                return new RootEntity.AnyOf0Entity(items);
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
            public Menes.ValidationContext Validate(Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
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
                                result = arrayEnumerator.Current.As<RootEntity.AnyOf0Entity.Items1Entity>().Validate(result, level);
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
                if (typeof(T) == typeof(AnyOf0Entity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<AnyOf0Entity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.AnyOf0Entity))
                {
                    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(T other)
                where T : struct, Menes.IJsonValue
            {
                return false;
            }
            public RootEntity.AnyOf0Entity.MenesArrayEnumerator GetEnumerator()
            {
                return new RootEntity.AnyOf0Entity.MenesArrayEnumerator(this);
            }
            public RootEntity.AnyOf0Entity.MenesArrayEnumerator EnumerateArray()
            {
                return new RootEntity.AnyOf0Entity.MenesArrayEnumerator(this);
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
            public AnyOf0Entity Add<T1>(T1 item1)
                where T1 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                return new RootEntity.AnyOf0Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf0Entity Add<T1, T2>(T1 item1, T2 item2)
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
                return new RootEntity.AnyOf0Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf0Entity Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
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
                return new RootEntity.AnyOf0Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf0Entity Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
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
                return new RootEntity.AnyOf0Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf0Entity Add<T>(params T[] items)
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
                return new RootEntity.AnyOf0Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf0Entity Insert<T>(int index, T item1)
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
                return new RootEntity.AnyOf0Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf0Entity Insert<T1, T2>(int index, T1 item1, T2 item2)
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
                return new RootEntity.AnyOf0Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf0Entity Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
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
                return new RootEntity.AnyOf0Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf0Entity Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
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
                return new RootEntity.AnyOf0Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf0Entity Insert<T>(int index, params T[] items)
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
                return new RootEntity.AnyOf0Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf0Entity RemoveAt(int index)
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
                return new RootEntity.AnyOf0Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf0Entity RemoveIf(System.Predicate<Menes.JsonAny> condition)
            {
                return this.RemoveIf<Menes.JsonAny>(condition);
            }
            public AnyOf0Entity RemoveIf<T>(System.Predicate<T> condition)
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
                return new RootEntity.AnyOf0Entity(arrayBuilder.ToImmutable());
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
                    return value.As<RootEntity.AnyOf0Entity.Items1Entity>();
                }
                public static implicit operator string(Items1Entity value)
                {
                    return (string)(Menes.JsonString)value;
                }
                public static implicit operator Items1Entity(string value)
                {
                    return (RootEntity.AnyOf0Entity.Items1Entity)(Menes.JsonString)value;
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
                public Menes.ValidationContext Validate(Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
                {
                    Menes.ValidationContext result = validationContext;
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
                    if (typeof(T) == typeof(RootEntity.AnyOf0Entity.Items1Entity))
                    {
                        return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                    }
                    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                /// <inheritdoc/>
                public bool Equals<T>(T other)
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
            /// An enumerator for the array values in a <see cref="AnyOf0Entity"/>.
            /// </summary>
            public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonAny>, System.Collections.IEnumerator
            {
                private AnyOf0Entity instance;
                private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                internal MenesArrayEnumerator(AnyOf0Entity instance)
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
                /// <returns>An enumerator for the array values in a <see cref="AnyOf0Entity"/>.</returns>
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
        public readonly struct AnyOf1Entity : Menes.IJsonValue, Menes.IJsonArray<AnyOf1Entity, Menes.JsonAny>
        {
            public static readonly AnyOf1Entity Null = default(AnyOf1Entity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? _menesArrayValueBacking;
            public AnyOf1Entity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesArrayValueBacking = default;
            }
            public AnyOf1Entity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> value)
            {
                this._menesArrayValueBacking = value;
                this._menesJsonElementBacking = default;
            }
            public static implicit operator AnyOf1Entity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> items)
            {
                return new RootEntity.AnyOf1Entity(items);
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
            public Menes.ValidationContext Validate(Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
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
                                result = arrayEnumerator.Current.As<RootEntity.AnyOf1Entity.Items2Entity>().Validate(result, level);
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
                if (typeof(T) == typeof(AnyOf1Entity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<AnyOf1Entity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.AnyOf1Entity))
                {
                    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(T other)
                where T : struct, Menes.IJsonValue
            {
                return false;
            }
            public RootEntity.AnyOf1Entity.MenesArrayEnumerator GetEnumerator()
            {
                return new RootEntity.AnyOf1Entity.MenesArrayEnumerator(this);
            }
            public RootEntity.AnyOf1Entity.MenesArrayEnumerator EnumerateArray()
            {
                return new RootEntity.AnyOf1Entity.MenesArrayEnumerator(this);
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
            public AnyOf1Entity Add<T1>(T1 item1)
                where T1 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                return new RootEntity.AnyOf1Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf1Entity Add<T1, T2>(T1 item1, T2 item2)
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
                return new RootEntity.AnyOf1Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf1Entity Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
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
                return new RootEntity.AnyOf1Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf1Entity Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
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
                return new RootEntity.AnyOf1Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf1Entity Add<T>(params T[] items)
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
                return new RootEntity.AnyOf1Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf1Entity Insert<T>(int index, T item1)
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
                return new RootEntity.AnyOf1Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf1Entity Insert<T1, T2>(int index, T1 item1, T2 item2)
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
                return new RootEntity.AnyOf1Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf1Entity Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
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
                return new RootEntity.AnyOf1Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf1Entity Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
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
                return new RootEntity.AnyOf1Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf1Entity Insert<T>(int index, params T[] items)
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
                return new RootEntity.AnyOf1Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf1Entity RemoveAt(int index)
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
                return new RootEntity.AnyOf1Entity(arrayBuilder.ToImmutable());
            }
            public AnyOf1Entity RemoveIf(System.Predicate<Menes.JsonAny> condition)
            {
                return this.RemoveIf<Menes.JsonAny>(condition);
            }
            public AnyOf1Entity RemoveIf<T>(System.Predicate<T> condition)
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
                return new RootEntity.AnyOf1Entity(arrayBuilder.ToImmutable());
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
                private static readonly Menes.JsonString _MenesConstValue = new Menes.JsonString("baz");
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
                    return value.As<RootEntity.AnyOf1Entity.Items2Entity>();
                }
                public static implicit operator string(Items2Entity value)
                {
                    return (string)(Menes.JsonString)value;
                }
                public static implicit operator Items2Entity(string value)
                {
                    return (RootEntity.AnyOf1Entity.Items2Entity)(Menes.JsonString)value;
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
                public Menes.ValidationContext Validate(Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
                {
                    Menes.ValidationContext result = validationContext;
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
                            result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"baz\"");
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
                                result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"baz\"");
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
                    if (typeof(T) == typeof(RootEntity.AnyOf1Entity.Items2Entity))
                    {
                        return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                    }
                    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                /// <inheritdoc/>
                public bool Equals<T>(T other)
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
            /// An enumerator for the array values in a <see cref="AnyOf1Entity"/>.
            /// </summary>
            public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonAny>, System.Collections.IEnumerator
            {
                private AnyOf1Entity instance;
                private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                internal MenesArrayEnumerator(AnyOf1Entity instance)
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
                /// <returns>An enumerator for the array values in a <see cref="AnyOf1Entity"/>.</returns>
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
            public Menes.ValidationContext Validate(Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
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
            public bool Equals<T>(T other)
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
