// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace ItemsFeature.ItemsAndSubitems
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
                            result = arrayEnumerator.Current.As<RootEntity.ItemArray>().Validate(result, level);
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                            {
                                return result;
                            }
                            result = result.WithLocalItemIndex(arrayLength);
                            break;
                        case 1:
                            result = arrayEnumerator.Current.As<RootEntity.ItemArray>().Validate(result, level);
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                            {
                                return result;
                            }
                            result = result.WithLocalItemIndex(arrayLength);
                            break;
                        case 2:
                            result = arrayEnumerator.Current.As<RootEntity.ItemArray>().Validate(result, level);
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                            {
                                return result;
                            }
                            result = result.WithLocalItemIndex(arrayLength);
                            break;
                        default:
                            if (level >= Menes.ValidationLevel.Basic)
                            {
                                result = result.WithResult(isValid: false, message: "9.3.1.2. additionalItems");
                            }
                            else
                            {
                                result = result.WithResult(isValid: false);
                            }
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                            {
                                return result;
                            }
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
        public readonly struct ItemArray : Menes.IJsonValue, Menes.IJsonArray<ItemArray, Menes.JsonAny>
        {
            public static readonly ItemArray Null = default(ItemArray);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? _menesArrayValueBacking;
            public ItemArray(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesArrayValueBacking = default;
            }
            public ItemArray(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> value)
            {
                this._menesArrayValueBacking = value;
                this._menesJsonElementBacking = default;
            }
            public static implicit operator ItemArray(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> items)
            {
                return new RootEntity.ItemArray(items);
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
                                result = arrayEnumerator.Current.As<RootEntity.ItemArray.SubItemEntity>().Validate(result, level);
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
                                result = result.WithLocalItemIndex(arrayLength);
                                break;
                            case 1:
                                result = arrayEnumerator.Current.As<RootEntity.ItemArray.SubItemEntity>().Validate(result, level);
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
                                result = result.WithLocalItemIndex(arrayLength);
                                break;
                            default:
                                if (level >= Menes.ValidationLevel.Basic)
                                {
                                    result = result.WithResult(isValid: false, message: "9.3.1.2. additionalItems");
                                }
                                else
                                {
                                    result = result.WithResult(isValid: false);
                                }
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
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
                if (typeof(T) == typeof(ItemArray))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<ItemArray, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.ItemArray))
                {
                    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
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
            public RootEntity.ItemArray.MenesArrayEnumerator GetEnumerator()
            {
                return new RootEntity.ItemArray.MenesArrayEnumerator(this);
            }
            public RootEntity.ItemArray.MenesArrayEnumerator EnumerateArray()
            {
                return new RootEntity.ItemArray.MenesArrayEnumerator(this);
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
            public ItemArray Add<T1>(T1 item1)
                where T1 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                return new RootEntity.ItemArray(arrayBuilder.ToImmutable());
            }
            public ItemArray Add<T1, T2>(T1 item1, T2 item2)
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
                return new RootEntity.ItemArray(arrayBuilder.ToImmutable());
            }
            public ItemArray Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
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
                return new RootEntity.ItemArray(arrayBuilder.ToImmutable());
            }
            public ItemArray Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
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
                return new RootEntity.ItemArray(arrayBuilder.ToImmutable());
            }
            public ItemArray Add<T>(params T[] items)
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
                return new RootEntity.ItemArray(arrayBuilder.ToImmutable());
            }
            public ItemArray Insert<T>(int index, T item1)
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
                return new RootEntity.ItemArray(arrayBuilder.ToImmutable());
            }
            public ItemArray Insert<T1, T2>(int index, T1 item1, T2 item2)
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
                return new RootEntity.ItemArray(arrayBuilder.ToImmutable());
            }
            public ItemArray Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
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
                return new RootEntity.ItemArray(arrayBuilder.ToImmutable());
            }
            public ItemArray Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
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
                return new RootEntity.ItemArray(arrayBuilder.ToImmutable());
            }
            public ItemArray Insert<T>(int index, params T[] items)
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
                return new RootEntity.ItemArray(arrayBuilder.ToImmutable());
            }
            public ItemArray RemoveAt(int index)
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
                return new RootEntity.ItemArray(arrayBuilder.ToImmutable());
            }
            public ItemArray RemoveIf(System.Predicate<Menes.JsonAny> condition)
            {
                return this.RemoveIf<Menes.JsonAny>(condition);
            }
            public ItemArray RemoveIf<T>(System.Predicate<T> condition)
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
                return new RootEntity.ItemArray(arrayBuilder.ToImmutable());
            }
            private bool AllBackingFieldsAreNull()
            {
                if (this._menesArrayValueBacking is not null)
                {
                    return false;
                }
                return true;
            }
            public readonly struct SubItemEntity : Menes.IJsonObject<SubItemEntity>
            {
                public static readonly SubItemEntity Null = default(SubItemEntity);
                private static readonly System.ReadOnlyMemory<char> _MenesFooJsonPropertyName = System.MemoryExtensions.AsMemory("foo");
                private static readonly System.ReadOnlyMemory<byte> _MenesFooUtf8JsonPropertyName = new byte[] { 102, 111, 111 };
                private static readonly System.Text.Json.JsonEncodedText _MenesFooEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesFooUtf8JsonPropertyName.Span);
                private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
                private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
                private readonly Menes.JsonAny? foo;
                public SubItemEntity(System.Text.Json.JsonElement jsonElement)
                {
                    this._menesJsonElementBacking = jsonElement;
                    this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
                    this.foo = default;
                }
                public SubItemEntity(Menes.JsonAny foo)
                {
                    this._menesJsonElementBacking = default;
                    this.foo = foo;
                    this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
                }
                private SubItemEntity(Menes.JsonAny? foo, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
                {
                    this._menesJsonElementBacking = default;
                    this.foo = foo;
                    this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
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
                public bool IsObject => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object) || (!this.HasJsonElement && !this.AllBackingFieldsAreNull());
                /// <inheritdoc />
                public bool IsBoolean => false;
                /// <inheritdoc />
                public bool IsArray => false;
                /// <inheritdoc />
                public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
                /// <inheritdoc />
                public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
                public Menes.JsonAny Foo => this.HasJsonElement ? this.GetPropertyFromJsonElement<Menes.JsonAny>(_MenesFooUtf8JsonPropertyName.Span) : this.foo ?? Menes.JsonAny.Null;
                public int PropertyCount
                {
                    get
                    {
                        if (this.HasJsonElement)
                        {
                            int jsonPropertyIndex = 0;
                            foreach (var property in this.JsonElement.EnumerateObject())
                            {
                                jsonPropertyIndex++;
                            }
                            return jsonPropertyIndex;
                        }
                        else
                        {
                            return 1 + this._menesAdditionalPropertiesBacking.Length;
                        }
                    }
                }
                /// <inheritdoc />
                public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
                {
                    Menes.ValidationContext result = validationContext;
                    if (level != Menes.ValidationLevel.Flag)
                    {
                        result = result.UsingStack();
                    }
                    if (!this.IsObject)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of object");
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
                    if (this.IsObject)
                    {
                        result = result.WithLocalProperty("foo");
                        if (this.TryGetProperty<Menes.JsonAny>(_MenesFooJsonPropertyName.Span, out Menes.JsonAny value0))
                        {
                            result = value0.Validate(result, level);
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                            {
                                return result;
                            }
                        }
                        else
                        {
                            if (level >= Menes.ValidationLevel.Basic)
                            {
                                result = result.WithResult(isValid: false, message: "6.5.3. required - required property not present.");
                            }
                            else
                            {
                                result = result.WithResult(isValid: false);
                            }
                            if (level == Menes.ValidationLevel.Flag)
                            {
                                return result;
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
                    writer.WriteStartObject();
                    if (this.foo is Menes.JsonAny foo)
                    {
                        writer.WritePropertyName(_MenesFooEncodedJsonPropertyName);
                        foo.WriteTo(writer);
                    }
                    foreach (var property in this._menesAdditionalPropertiesBacking)
                    {
                        property.WriteTo(writer);
                    }
                    writer.WriteEndObject();
                }
                /// <inheritdoc />
                public T As<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(SubItemEntity))
                    {
                        return Corvus.Extensions.CastTo<T>.From(this);
                    }
                    return Menes.JsonValue.As<SubItemEntity, T>(this);
                }
                /// <inheritdoc />
                public bool Is<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(RootEntity.ItemArray.SubItemEntity))
                    {
                        return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                    }
                    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                /// <inheritdoc/>
                public bool Equals<T>(in T other)
                    where T : struct, Menes.IJsonValue
                {
                    if (!other.IsObject)
                    {
                        return false;
                    }
                    var otherObject = Corvus.Extensions.CastTo<Menes.IJsonObject>.From(other);
                    MenesPropertyEnumerator firstEnumerator = this.EnumerateObject();
                    if (this.PropertyCount != otherObject.PropertyCount)
                    {
                        return false;
                    }
                    while (firstEnumerator.MoveNext())
                    {
                        if (!otherObject.TryGetProperty<Menes.JsonAny>(firstEnumerator.Current.NameAsMemory.Span, out Menes.JsonAny otherProperty))
                        {
                            return false;
                        }
                        if (!firstEnumerator.Current.Value<Menes.JsonAny>().Equals(otherProperty))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                /// <inheritdoc/>
                public bool HasProperty(System.ReadOnlySpan<char> propertyName)
                {
                    if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
                    {
                        return true;
                    }
                    else
                    {
                        if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooJsonPropertyName.Span))
                        {
                            return true;
                        }
                        foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                        {
                            if (additionalProperty.NameEquals(propertyName))
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
                /// <inheritdoc/>
                public bool HasProperty(string propertyName)
                {
                    if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
                    {
                        return true;
                    }
                    else
                    {
                        if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooJsonPropertyName.Span))
                        {
                            return true;
                        }
                        foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                        {
                            if (additionalProperty.NameEquals(propertyName))
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
                /// <inheritdoc/>
                public bool HasProperty(System.ReadOnlySpan<byte> propertyName)
                {
                    if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
                    {
                        return true;
                    }
                    else
                    {
                        if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooUtf8JsonPropertyName.Span))
                        {
                            return true;
                        }
                        foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                        {
                            if (additionalProperty.NameEquals(propertyName))
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
                /// <inheritdoc />
                public bool TryGetProperty<T>(System.ReadOnlySpan<char> propertyName, out T property)
                    where T : struct, Menes.IJsonValue
                {
                    if (this.HasJsonElement)
                    {
                        if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                        {
                            property = Menes.JsonValue.As<T>(value);
                            return true;
                        }
                        property = default;
                        return false;
                    }
                    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooJsonPropertyName.Span))
                    {
                        property = this.Foo.As<T>();
                        return true;
                    }
                    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                    {
                        if (additionalProperty.NameEquals(propertyName))
                        {
                            property = additionalProperty.Value.As<T>();
                            return true;
                        }
                    }
                    property = default;
                    return false;
                }
                /// <inheritdoc />
                public bool TryGetProperty<T>(string propertyName, out T property)
                    where T : struct, Menes.IJsonValue
                {
                    if (this.HasJsonElement)
                    {
                        if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                        {
                            property = Menes.JsonValue.As<T>(value);
                            return true;
                        }
                        property = default;
                        return false;
                    }
                    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooJsonPropertyName.Span))
                    {
                        property = this.Foo.As<T>();
                        return true;
                    }
                    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                    {
                        if (additionalProperty.NameEquals(propertyName))
                        {
                            property = additionalProperty.Value.As<T>();
                            return true;
                        }
                    }
                    property = default;
                    return false;
                }
                /// <inheritdoc />
                public bool TryGetProperty<T>(System.ReadOnlySpan<byte> propertyName, out T property)
                    where T : struct, Menes.IJsonValue
                {
                    if (this.HasJsonElement)
                    {
                        if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                        {
                            property = Menes.JsonValue.As<T>(value);
                            return true;
                        }
                        property = default;
                        return false;
                    }
                    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooUtf8JsonPropertyName.Span))
                    {
                        property = this.Foo.As<T>();
                        return true;
                    }
                    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                    {
                        if (additionalProperty.NameEquals(propertyName))
                        {
                            property = additionalProperty.Value.As<T>();
                            return true;
                        }
                    }
                    property = default;
                    return false;
                }
                /// <inheritdoc />
                public bool TryGetPropertyAtIndex(int index, out Menes.IProperty result)
                {
                    var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<SubItemEntity> prop);
                    result = prop;
                    return rc;
                }
                public SubItemEntity RemoveProperty(string propertyName)
                {
                    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
                }
                public SubItemEntity RemoveProperty(System.ReadOnlySpan<char> propertyName)
                {
                    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
                }
                public SubItemEntity RemoveProperty(System.ReadOnlySpan<byte> propertyName)
                {
                    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
                }
                public SubItemEntity SetProperty<T>(string name, T value)
                where T : struct, Menes.IJsonValue
                {
                    var propertyName = System.MemoryExtensions.AsSpan(name);
                    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooJsonPropertyName.Span))
                    {
                        return this.WithFoo(value.As<Menes.JsonAny>());
                    }
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonAny>>();
                    bool added = false;
                    foreach (var property in this._menesAdditionalPropertiesBacking)
                    {
                        if (!property.NameEquals(propertyName))
                        {
                            arrayBuilder.Add(property);
                        }
                        else
                        {
                            arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
                            added = true;
                        }
                    }
                    if (!added)
                    {
                        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
                    }
                    return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                    return this;
                }
                public SubItemEntity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
                where T : struct, Menes.IJsonValue
                {
                    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooJsonPropertyName.Span))
                    {
                        return this.WithFoo(value.As<Menes.JsonAny>());
                    }
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonAny>>();
                    bool added = false;
                    foreach (var property in this._menesAdditionalPropertiesBacking)
                    {
                        if (!property.NameEquals(propertyName))
                        {
                            arrayBuilder.Add(property);
                        }
                        else
                        {
                            arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
                            added = true;
                        }
                    }
                    if (!added)
                    {
                        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
                    }
                    return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                    return this;
                }
                public SubItemEntity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
                where T : struct, Menes.IJsonValue
                {
                    System.Span<char> name = stackalloc char[utf8Name.Length];
                    int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
                    var propertyName = name.Slice(0, writtenCount);
                    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooJsonPropertyName.Span))
                    {
                        return this.WithFoo(value.As<Menes.JsonAny>());
                    }
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonAny>>();
                    bool added = false;
                    foreach (var property in this._menesAdditionalPropertiesBacking)
                    {
                        if (!property.NameEquals(propertyName))
                        {
                            arrayBuilder.Add(property);
                        }
                        else
                        {
                            arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
                            added = true;
                        }
                    }
                    if (!added)
                    {
                        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
                    }
                    return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                    return this;
                }
                public RootEntity.ItemArray.SubItemEntity.MenesPropertyEnumerator GetEnumerator()
                {
                    return new MenesPropertyEnumerator(this);
                }
                /// <summary>
                /// Enumerate the properties in the object.
                /// </summary>
                /// <returns>The object enumerator.</returns>
                public MenesPropertyEnumerator EnumerateObject()
                {
                    return new MenesPropertyEnumerator(this);
                }
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                System.Collections.Generic.IEnumerator<Menes.Property<RootEntity.ItemArray.SubItemEntity>> System.Collections.Generic.IEnumerable<Menes.Property<RootEntity.ItemArray.SubItemEntity>>.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                public SubItemEntity WithFoo(Menes.JsonAny value)
                {
                    return new SubItemEntity(value, this._menesAdditionalPropertiesBacking);
                }
                private TPropertyValue GetPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
                    where TPropertyValue : struct, Menes.IJsonValue
                {
                    return this.GetOptionalPropertyFromJsonElement<TPropertyValue>(propertyName) ?? default;
                }
                private TPropertyValue? GetOptionalPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
                    where TPropertyValue : struct, Menes.IJsonValue
                {
                    return this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object ?
                         (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                             ? Menes.JsonValue.As<TPropertyValue>(property)
                             : null)
                         : null;
                }
                private bool AllBackingFieldsAreNull()
                {
                    if (this.foo is not null)
                    {
                        return false;
                    }
                    if (this._menesAdditionalPropertiesBacking.Length > 0)
                    {
                        return false;
                    }
                    return true;
                }
                /// <inheritdoc />
                private bool TryGetPropertyAtIndex(int index, out Menes.Property<SubItemEntity> result)
                {
                    if (this.HasJsonElement)
                    {
                        int jsonPropertyIndex = 0;
                        foreach (var property in this.JsonElement.EnumerateObject())
                        {
                            if (jsonPropertyIndex == index)
                            {
                                result = new Menes.Property<SubItemEntity>(property);
                                return true;
                            }
                            jsonPropertyIndex++;
                        }
                    }
                    int currentIndex = 0;
                    if (currentIndex == index)
                    {
                        result = new Menes.Property<SubItemEntity>(this, _MenesFooJsonPropertyName);
                        return true;
                    }
                    currentIndex++;
                    foreach (var property in this._menesAdditionalPropertiesBacking)
                    {
                        if (currentIndex == index)
                        {
                            result = new Menes.Property<SubItemEntity>(this, property.NameAsMemory);
                            return true;
                        }
                        currentIndex++;
                    }
                    result = default; ;
                    return false;
                }
                private SubItemEntity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> value)
                {
                    return new SubItemEntity(this.foo, value);
                }
                /// <summary>
                /// An enumerator for the properties in a <see cref="SubItemEntity"/>.
                /// </summary>
                public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<SubItemEntity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<SubItemEntity>>, System.Collections.IEnumerator
                {
                    private SubItemEntity instance;
                    private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
                    private bool hasJsonEnumerator;
                    private int index;
                    private int propertyCount;
                    internal MenesPropertyEnumerator(SubItemEntity instance)
                    {
                        this.instance = instance;
                        this.propertyCount = instance.PropertyCount;
                        if (this.instance.HasJsonElement)
                        {
                            this.index = -2;
                            this.hasJsonEnumerator = true;
                            this.jsonEnumerator = this.instance.JsonElement.EnumerateObject();
                        }
                        else
                        {
                            this.index = -1;
                            this.hasJsonEnumerator = false;
                            this.jsonEnumerator = default;
                        }
                    }
                    /// <inheritdoc/>
                    public Menes.Property<SubItemEntity> Current
                    {
                        get
                        {
                            if (this.hasJsonEnumerator)
                            {
                                return new Menes.Property<SubItemEntity>(this.jsonEnumerator.Current);
                            }
                            else if (this.index >= 0)
                            {
                                if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<SubItemEntity> result))
                                {
                                    return result;
                                }
                                throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                            }
                            return new Menes.Property<SubItemEntity>(this.instance, default);
                        }
                    }
                    /// <inheritdoc/>
                    object System.Collections.IEnumerator.Current => this.Current;
                    /// <summary>
                    /// Returns a fresh copy of the enumerator
                    /// </summary>
                    /// <returns>An enumerator for the properties in a <see cref="SubItemEntity"/>.</returns>
                    public MenesPropertyEnumerator GetEnumerator()
                    {
                        MenesPropertyEnumerator result = this;
                        result.Reset();
                        return result;
                    }
                    /// <inheritdoc/>
                    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                    {
                        return this.GetEnumerator();
                    }
                    /// <inheritdoc/>
                    System.Collections.Generic.IEnumerator<Menes.Property<SubItemEntity>> System.Collections.Generic.IEnumerable<Menes.Property<SubItemEntity>>.GetEnumerator()
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
                    }
                    /// <inheritdoc/>
                    public bool MoveNext()
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return this.jsonEnumerator.MoveNext();
                        }
                        else
                        {
                            if (this.index + 1 < this.propertyCount)
                            {
                                this.index++;
                                return true;
                            }
                            return false;
                        }
                    }
                }
            }
            /// <summary>
            /// An enumerator for the array values in a <see cref="ItemArray"/>.
            /// </summary>
            public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonAny>, System.Collections.IEnumerator
            {
                private ItemArray instance;
                private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                internal MenesArrayEnumerator(ItemArray instance)
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
                /// <returns>An enumerator for the array values in a <see cref="ItemArray"/>.</returns>
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
