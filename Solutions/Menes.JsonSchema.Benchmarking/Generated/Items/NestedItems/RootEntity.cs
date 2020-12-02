// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace ItemsFeature.NestedItems
{
    public readonly struct RootEntity : Menes.IJsonValue, Menes.IJsonArray<RootEntity, RootEntity.ItemsArray>
    {
        public static readonly RootEntity Null = default(RootEntity);
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray>? _menesArrayValueBacking;
        public RootEntity(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
            this._menesArrayValueBacking = default;
        }
        public RootEntity(System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray> value)
        {
            this._menesArrayValueBacking = value;
            this._menesJsonElementBacking = default;
        }
        public static implicit operator RootEntity(System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray> items)
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
                    result = arrayEnumerator.Current.As<RootEntity.ItemsArray>().Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                    result = result.WithLocalItemIndex(arrayLength);
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
        System.Collections.Generic.IEnumerator<RootEntity.ItemsArray> System.Collections.Generic.IEnumerable<RootEntity.ItemsArray>.GetEnumerator()
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
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray>();
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                arrayBuilder.Add(oldItem);
            }
            arrayBuilder.Add(item1.As<RootEntity.ItemsArray>());
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Add<T1, T2>(T1 item1, T2 item2)
            where T1 : struct, Menes.IJsonValue
            where T2 : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray>();
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                arrayBuilder.Add(oldItem);
            }
            arrayBuilder.Add(item1.As<RootEntity.ItemsArray>());
            arrayBuilder.Add(item2.As<RootEntity.ItemsArray>());
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
            where T1 : struct, Menes.IJsonValue
            where T2 : struct, Menes.IJsonValue
            where T3 : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray>();
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                arrayBuilder.Add(oldItem);
            }
            arrayBuilder.Add(item1.As<RootEntity.ItemsArray>());
            arrayBuilder.Add(item2.As<RootEntity.ItemsArray>());
            arrayBuilder.Add(item3.As<RootEntity.ItemsArray>());
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
            where T1 : struct, Menes.IJsonValue
            where T2 : struct, Menes.IJsonValue
            where T3 : struct, Menes.IJsonValue
            where T4 : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray>();
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                arrayBuilder.Add(oldItem);
            }
            arrayBuilder.Add(item1.As<RootEntity.ItemsArray>());
            arrayBuilder.Add(item2.As<RootEntity.ItemsArray>());
            arrayBuilder.Add(item3.As<RootEntity.ItemsArray>());
            arrayBuilder.Add(item4.As<RootEntity.ItemsArray>());
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Add<T>(params T[] items)
            where T : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray>();
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                arrayBuilder.Add(oldItem);
            }
            foreach (var item1 in items)
            {
                arrayBuilder.Add(item1.As<RootEntity.ItemsArray>());
            }
            return new RootEntity(arrayBuilder.ToImmutable());
        }
        public RootEntity Insert<T>(int index, T item1)
            where T : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray>();
            int currentIndex = 0;
            bool inserted = false;
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                if (currentIndex == index)
                {
                    arrayBuilder.Add(item1.As<RootEntity.ItemsArray>());
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
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray>();
            int currentIndex = 0;
            bool inserted = false;
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                if (currentIndex == index)
                {
                    arrayBuilder.Add(item1.As<RootEntity.ItemsArray>());
                    arrayBuilder.Add(item2.As<RootEntity.ItemsArray>());
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
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray>();
            int currentIndex = 0;
            bool inserted = false;
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                if (currentIndex == index)
                {
                    arrayBuilder.Add(item1.As<RootEntity.ItemsArray>());
                    arrayBuilder.Add(item2.As<RootEntity.ItemsArray>());
                    arrayBuilder.Add(item3.As<RootEntity.ItemsArray>());
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
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray>();
            int currentIndex = 0;
            bool inserted = false;
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                if (currentIndex == index)
                {
                    arrayBuilder.Add(item1.As<RootEntity.ItemsArray>());
                    arrayBuilder.Add(item2.As<RootEntity.ItemsArray>());
                    arrayBuilder.Add(item3.As<RootEntity.ItemsArray>());
                    arrayBuilder.Add(item4.As<RootEntity.ItemsArray>());
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
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray>();
            int currentIndex = 0;
            bool inserted = false;
            foreach (var oldItem in this._menesArrayValueBacking)
            {
                if (currentIndex == index)
                {
                    foreach (var item1 in items)
                    {
                        arrayBuilder.Add(item1.As<RootEntity.ItemsArray>());
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
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray>();
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
        public RootEntity RemoveIf(System.Predicate<RootEntity.ItemsArray> condition)
        {
            return this.RemoveIf<RootEntity.ItemsArray>(condition);
        }
        public RootEntity RemoveIf<T>(System.Predicate<T> condition)
            where T : struct, Menes.IJsonValue
        {
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray>();
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
        public readonly struct ItemsArray : Menes.IJsonValue, Menes.IJsonArray<ItemsArray, RootEntity.ItemsArray.Items0>
        {
            public static readonly ItemsArray Null = default(ItemsArray);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray.Items0>? _menesArrayValueBacking;
            public ItemsArray(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesArrayValueBacking = default;
            }
            public ItemsArray(System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray.Items0> value)
            {
                this._menesArrayValueBacking = value;
                this._menesJsonElementBacking = default;
            }
            public static implicit operator ItemsArray(System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray.Items0> items)
            {
                return new RootEntity.ItemsArray(items);
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
                        result = arrayEnumerator.Current.As<RootEntity.ItemsArray.Items0>().Validate(result, level);
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                        result = result.WithLocalItemIndex(arrayLength);
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
                if (typeof(T) == typeof(ItemsArray))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<ItemsArray, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.ItemsArray))
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
            public RootEntity.ItemsArray.MenesArrayEnumerator GetEnumerator()
            {
                return new RootEntity.ItemsArray.MenesArrayEnumerator(this);
            }
            public RootEntity.ItemsArray.MenesArrayEnumerator EnumerateArray()
            {
                return new RootEntity.ItemsArray.MenesArrayEnumerator(this);
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<RootEntity.ItemsArray.Items0> System.Collections.Generic.IEnumerable<RootEntity.ItemsArray.Items0>.GetEnumerator()
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
            public ItemsArray Add<T1>(T1 item1)
                where T1 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0>());
                return new RootEntity.ItemsArray(arrayBuilder.ToImmutable());
            }
            public ItemsArray Add<T1, T2>(T1 item1, T2 item2)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0>());
                arrayBuilder.Add(item2.As<RootEntity.ItemsArray.Items0>());
                return new RootEntity.ItemsArray(arrayBuilder.ToImmutable());
            }
            public ItemsArray Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0>());
                arrayBuilder.Add(item2.As<RootEntity.ItemsArray.Items0>());
                arrayBuilder.Add(item3.As<RootEntity.ItemsArray.Items0>());
                return new RootEntity.ItemsArray(arrayBuilder.ToImmutable());
            }
            public ItemsArray Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
                where T4 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0>());
                arrayBuilder.Add(item2.As<RootEntity.ItemsArray.Items0>());
                arrayBuilder.Add(item3.As<RootEntity.ItemsArray.Items0>());
                arrayBuilder.Add(item4.As<RootEntity.ItemsArray.Items0>());
                return new RootEntity.ItemsArray(arrayBuilder.ToImmutable());
            }
            public ItemsArray Add<T>(params T[] items)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                foreach (var item1 in items)
                {
                    arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0>());
                }
                return new RootEntity.ItemsArray(arrayBuilder.ToImmutable());
            }
            public ItemsArray Insert<T>(int index, T item1)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ItemsArray(arrayBuilder.ToImmutable());
            }
            public ItemsArray Insert<T1, T2>(int index, T1 item1, T2 item2)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0>());
                        arrayBuilder.Add(item2.As<RootEntity.ItemsArray.Items0>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ItemsArray(arrayBuilder.ToImmutable());
            }
            public ItemsArray Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0>());
                        arrayBuilder.Add(item2.As<RootEntity.ItemsArray.Items0>());
                        arrayBuilder.Add(item3.As<RootEntity.ItemsArray.Items0>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ItemsArray(arrayBuilder.ToImmutable());
            }
            public ItemsArray Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
                where T4 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0>());
                        arrayBuilder.Add(item2.As<RootEntity.ItemsArray.Items0>());
                        arrayBuilder.Add(item3.As<RootEntity.ItemsArray.Items0>());
                        arrayBuilder.Add(item4.As<RootEntity.ItemsArray.Items0>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new RootEntity.ItemsArray(arrayBuilder.ToImmutable());
            }
            public ItemsArray Insert<T>(int index, params T[] items)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        foreach (var item1 in items)
                        {
                            arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0>());
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
                return new RootEntity.ItemsArray(arrayBuilder.ToImmutable());
            }
            public ItemsArray RemoveAt(int index)
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0>();
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
                return new RootEntity.ItemsArray(arrayBuilder.ToImmutable());
            }
            public ItemsArray RemoveIf(System.Predicate<RootEntity.ItemsArray.Items0> condition)
            {
                return this.RemoveIf<RootEntity.ItemsArray.Items0>(condition);
            }
            public ItemsArray RemoveIf<T>(System.Predicate<T> condition)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0>();
                foreach (var item in this._menesArrayValueBacking)
                {
                    if (!condition(item.As<T>()))
                    {
                        arrayBuilder.Add(item);
                    }
                }
                return new RootEntity.ItemsArray(arrayBuilder.ToImmutable());
            }
            private bool AllBackingFieldsAreNull()
            {
                if (this._menesArrayValueBacking is not null)
                {
                    return false;
                }
                return true;
            }
            public readonly struct Items0 : Menes.IJsonValue, Menes.IJsonArray<Items0, RootEntity.ItemsArray.Items0.ItemsArray>
            {
                public static readonly Items0 Null = default(Items0);
                private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
                private readonly System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray.Items0.ItemsArray>? _menesArrayValueBacking;
                public Items0(System.Text.Json.JsonElement jsonElement)
                {
                    this._menesJsonElementBacking = jsonElement;
                    this._menesArrayValueBacking = default;
                }
                public Items0(System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray.Items0.ItemsArray> value)
                {
                    this._menesArrayValueBacking = value;
                    this._menesJsonElementBacking = default;
                }
                public static implicit operator Items0(System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray.Items0.ItemsArray> items)
                {
                    return new RootEntity.ItemsArray.Items0(items);
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
                            result = arrayEnumerator.Current.As<RootEntity.ItemsArray.Items0.ItemsArray>().Validate(result, level);
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                            {
                                return result;
                            }
                            result = result.WithLocalItemIndex(arrayLength);
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
                    if (typeof(T) == typeof(Items0))
                    {
                        return Corvus.Extensions.CastTo<T>.From(this);
                    }
                    return Menes.JsonValue.As<Items0, T>(this);
                }
                /// <inheritdoc />
                public bool Is<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(RootEntity.ItemsArray.Items0))
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
                public RootEntity.ItemsArray.Items0.MenesArrayEnumerator GetEnumerator()
                {
                    return new RootEntity.ItemsArray.Items0.MenesArrayEnumerator(this);
                }
                public RootEntity.ItemsArray.Items0.MenesArrayEnumerator EnumerateArray()
                {
                    return new RootEntity.ItemsArray.Items0.MenesArrayEnumerator(this);
                }
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                System.Collections.Generic.IEnumerator<RootEntity.ItemsArray.Items0.ItemsArray> System.Collections.Generic.IEnumerable<RootEntity.ItemsArray.Items0.ItemsArray>.GetEnumerator()
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
                public Items0 Add<T1>(T1 item1)
                    where T1 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0.ItemsArray>();
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        arrayBuilder.Add(oldItem);
                    }
                    arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                    return new RootEntity.ItemsArray.Items0(arrayBuilder.ToImmutable());
                }
                public Items0 Add<T1, T2>(T1 item1, T2 item2)
                    where T1 : struct, Menes.IJsonValue
                    where T2 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0.ItemsArray>();
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        arrayBuilder.Add(oldItem);
                    }
                    arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                    arrayBuilder.Add(item2.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                    return new RootEntity.ItemsArray.Items0(arrayBuilder.ToImmutable());
                }
                public Items0 Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
                    where T1 : struct, Menes.IJsonValue
                    where T2 : struct, Menes.IJsonValue
                    where T3 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0.ItemsArray>();
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        arrayBuilder.Add(oldItem);
                    }
                    arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                    arrayBuilder.Add(item2.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                    arrayBuilder.Add(item3.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                    return new RootEntity.ItemsArray.Items0(arrayBuilder.ToImmutable());
                }
                public Items0 Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
                    where T1 : struct, Menes.IJsonValue
                    where T2 : struct, Menes.IJsonValue
                    where T3 : struct, Menes.IJsonValue
                    where T4 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0.ItemsArray>();
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        arrayBuilder.Add(oldItem);
                    }
                    arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                    arrayBuilder.Add(item2.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                    arrayBuilder.Add(item3.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                    arrayBuilder.Add(item4.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                    return new RootEntity.ItemsArray.Items0(arrayBuilder.ToImmutable());
                }
                public Items0 Add<T>(params T[] items)
                    where T : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0.ItemsArray>();
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        arrayBuilder.Add(oldItem);
                    }
                    foreach (var item1 in items)
                    {
                        arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                    }
                    return new RootEntity.ItemsArray.Items0(arrayBuilder.ToImmutable());
                }
                public Items0 Insert<T>(int index, T item1)
                    where T : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0.ItemsArray>();
                    int currentIndex = 0;
                    bool inserted = false;
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        if (currentIndex == index)
                        {
                            arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                            inserted = true;
                        }
                        arrayBuilder.Add(oldItem);
                        currentIndex++;
                    }
                    if (!inserted)
                    {
                        throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                    }
                    return new RootEntity.ItemsArray.Items0(arrayBuilder.ToImmutable());
                }
                public Items0 Insert<T1, T2>(int index, T1 item1, T2 item2)
                    where T1 : struct, Menes.IJsonValue
                    where T2 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0.ItemsArray>();
                    int currentIndex = 0;
                    bool inserted = false;
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        if (currentIndex == index)
                        {
                            arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                            arrayBuilder.Add(item2.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                            inserted = true;
                        }
                        arrayBuilder.Add(oldItem);
                        currentIndex++;
                    }
                    if (!inserted)
                    {
                        throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                    }
                    return new RootEntity.ItemsArray.Items0(arrayBuilder.ToImmutable());
                }
                public Items0 Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
                    where T1 : struct, Menes.IJsonValue
                    where T2 : struct, Menes.IJsonValue
                    where T3 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0.ItemsArray>();
                    int currentIndex = 0;
                    bool inserted = false;
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        if (currentIndex == index)
                        {
                            arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                            arrayBuilder.Add(item2.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                            arrayBuilder.Add(item3.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                            inserted = true;
                        }
                        arrayBuilder.Add(oldItem);
                        currentIndex++;
                    }
                    if (!inserted)
                    {
                        throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                    }
                    return new RootEntity.ItemsArray.Items0(arrayBuilder.ToImmutable());
                }
                public Items0 Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
                    where T1 : struct, Menes.IJsonValue
                    where T2 : struct, Menes.IJsonValue
                    where T3 : struct, Menes.IJsonValue
                    where T4 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0.ItemsArray>();
                    int currentIndex = 0;
                    bool inserted = false;
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        if (currentIndex == index)
                        {
                            arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                            arrayBuilder.Add(item2.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                            arrayBuilder.Add(item3.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                            arrayBuilder.Add(item4.As<RootEntity.ItemsArray.Items0.ItemsArray>());
                            inserted = true;
                        }
                        arrayBuilder.Add(oldItem);
                        currentIndex++;
                    }
                    if (!inserted)
                    {
                        throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                    }
                    return new RootEntity.ItemsArray.Items0(arrayBuilder.ToImmutable());
                }
                public Items0 Insert<T>(int index, params T[] items)
                    where T : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0.ItemsArray>();
                    int currentIndex = 0;
                    bool inserted = false;
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        if (currentIndex == index)
                        {
                            foreach (var item1 in items)
                            {
                                arrayBuilder.Add(item1.As<RootEntity.ItemsArray.Items0.ItemsArray>());
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
                    return new RootEntity.ItemsArray.Items0(arrayBuilder.ToImmutable());
                }
                public Items0 RemoveAt(int index)
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0.ItemsArray>();
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
                    return new RootEntity.ItemsArray.Items0(arrayBuilder.ToImmutable());
                }
                public Items0 RemoveIf(System.Predicate<RootEntity.ItemsArray.Items0.ItemsArray> condition)
                {
                    return this.RemoveIf<RootEntity.ItemsArray.Items0.ItemsArray>(condition);
                }
                public Items0 RemoveIf<T>(System.Predicate<T> condition)
                    where T : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsArray.Items0.ItemsArray>();
                    foreach (var item in this._menesArrayValueBacking)
                    {
                        if (!condition(item.As<T>()))
                        {
                            arrayBuilder.Add(item);
                        }
                    }
                    return new RootEntity.ItemsArray.Items0(arrayBuilder.ToImmutable());
                }
                private bool AllBackingFieldsAreNull()
                {
                    if (this._menesArrayValueBacking is not null)
                    {
                        return false;
                    }
                    return true;
                }
                public readonly struct ItemsArray : Menes.IJsonValue, Menes.IJsonArray<ItemsArray, Menes.JsonNumber>
                {
                    public static readonly ItemsArray Null = default(ItemsArray);
                    private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
                    private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>? _menesArrayValueBacking;
                    public ItemsArray(System.Text.Json.JsonElement jsonElement)
                    {
                        this._menesJsonElementBacking = jsonElement;
                        this._menesArrayValueBacking = default;
                    }
                    public ItemsArray(System.Collections.Immutable.ImmutableArray<Menes.JsonNumber> value)
                    {
                        this._menesArrayValueBacking = value;
                        this._menesJsonElementBacking = default;
                    }
                    public static implicit operator ItemsArray(System.Collections.Immutable.ImmutableArray<Menes.JsonNumber> items)
                    {
                        return new RootEntity.ItemsArray.Items0.ItemsArray(items);
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
                                result = arrayEnumerator.Current.As<Menes.JsonNumber>().Validate(result, level);
                                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }
                                result = result.WithLocalItemIndex(arrayLength);
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
                        if (typeof(T) == typeof(ItemsArray))
                        {
                            return Corvus.Extensions.CastTo<T>.From(this);
                        }
                        return Menes.JsonValue.As<ItemsArray, T>(this);
                    }
                    /// <inheritdoc />
                    public bool Is<T>()
                        where T : struct, Menes.IJsonValue
                    {
                        if (typeof(T) == typeof(RootEntity.ItemsArray.Items0.ItemsArray))
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
                    public RootEntity.ItemsArray.Items0.ItemsArray.MenesArrayEnumerator GetEnumerator()
                    {
                        return new RootEntity.ItemsArray.Items0.ItemsArray.MenesArrayEnumerator(this);
                    }
                    public RootEntity.ItemsArray.Items0.ItemsArray.MenesArrayEnumerator EnumerateArray()
                    {
                        return new RootEntity.ItemsArray.Items0.ItemsArray.MenesArrayEnumerator(this);
                    }
                    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                    {
                        return this.GetEnumerator();
                    }
                    System.Collections.Generic.IEnumerator<Menes.JsonNumber> System.Collections.Generic.IEnumerable<Menes.JsonNumber>.GetEnumerator()
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
                    public ItemsArray Add<T1>(T1 item1)
                        where T1 : struct, Menes.IJsonValue
                    {
                        var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                        foreach (var oldItem in this._menesArrayValueBacking)
                        {
                            arrayBuilder.Add(oldItem);
                        }
                        arrayBuilder.Add(item1.As<Menes.JsonNumber>());
                        return new RootEntity.ItemsArray.Items0.ItemsArray(arrayBuilder.ToImmutable());
                    }
                    public ItemsArray Add<T1, T2>(T1 item1, T2 item2)
                        where T1 : struct, Menes.IJsonValue
                        where T2 : struct, Menes.IJsonValue
                    {
                        var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                        foreach (var oldItem in this._menesArrayValueBacking)
                        {
                            arrayBuilder.Add(oldItem);
                        }
                        arrayBuilder.Add(item1.As<Menes.JsonNumber>());
                        arrayBuilder.Add(item2.As<Menes.JsonNumber>());
                        return new RootEntity.ItemsArray.Items0.ItemsArray(arrayBuilder.ToImmutable());
                    }
                    public ItemsArray Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
                        where T1 : struct, Menes.IJsonValue
                        where T2 : struct, Menes.IJsonValue
                        where T3 : struct, Menes.IJsonValue
                    {
                        var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                        foreach (var oldItem in this._menesArrayValueBacking)
                        {
                            arrayBuilder.Add(oldItem);
                        }
                        arrayBuilder.Add(item1.As<Menes.JsonNumber>());
                        arrayBuilder.Add(item2.As<Menes.JsonNumber>());
                        arrayBuilder.Add(item3.As<Menes.JsonNumber>());
                        return new RootEntity.ItemsArray.Items0.ItemsArray(arrayBuilder.ToImmutable());
                    }
                    public ItemsArray Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
                        where T1 : struct, Menes.IJsonValue
                        where T2 : struct, Menes.IJsonValue
                        where T3 : struct, Menes.IJsonValue
                        where T4 : struct, Menes.IJsonValue
                    {
                        var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                        foreach (var oldItem in this._menesArrayValueBacking)
                        {
                            arrayBuilder.Add(oldItem);
                        }
                        arrayBuilder.Add(item1.As<Menes.JsonNumber>());
                        arrayBuilder.Add(item2.As<Menes.JsonNumber>());
                        arrayBuilder.Add(item3.As<Menes.JsonNumber>());
                        arrayBuilder.Add(item4.As<Menes.JsonNumber>());
                        return new RootEntity.ItemsArray.Items0.ItemsArray(arrayBuilder.ToImmutable());
                    }
                    public ItemsArray Add<T>(params T[] items)
                        where T : struct, Menes.IJsonValue
                    {
                        var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                        foreach (var oldItem in this._menesArrayValueBacking)
                        {
                            arrayBuilder.Add(oldItem);
                        }
                        foreach (var item1 in items)
                        {
                            arrayBuilder.Add(item1.As<Menes.JsonNumber>());
                        }
                        return new RootEntity.ItemsArray.Items0.ItemsArray(arrayBuilder.ToImmutable());
                    }
                    public ItemsArray Insert<T>(int index, T item1)
                        where T : struct, Menes.IJsonValue
                    {
                        var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                        int currentIndex = 0;
                        bool inserted = false;
                        foreach (var oldItem in this._menesArrayValueBacking)
                        {
                            if (currentIndex == index)
                            {
                                arrayBuilder.Add(item1.As<Menes.JsonNumber>());
                                inserted = true;
                            }
                            arrayBuilder.Add(oldItem);
                            currentIndex++;
                        }
                        if (!inserted)
                        {
                            throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                        }
                        return new RootEntity.ItemsArray.Items0.ItemsArray(arrayBuilder.ToImmutable());
                    }
                    public ItemsArray Insert<T1, T2>(int index, T1 item1, T2 item2)
                        where T1 : struct, Menes.IJsonValue
                        where T2 : struct, Menes.IJsonValue
                    {
                        var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                        int currentIndex = 0;
                        bool inserted = false;
                        foreach (var oldItem in this._menesArrayValueBacking)
                        {
                            if (currentIndex == index)
                            {
                                arrayBuilder.Add(item1.As<Menes.JsonNumber>());
                                arrayBuilder.Add(item2.As<Menes.JsonNumber>());
                                inserted = true;
                            }
                            arrayBuilder.Add(oldItem);
                            currentIndex++;
                        }
                        if (!inserted)
                        {
                            throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                        }
                        return new RootEntity.ItemsArray.Items0.ItemsArray(arrayBuilder.ToImmutable());
                    }
                    public ItemsArray Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
                        where T1 : struct, Menes.IJsonValue
                        where T2 : struct, Menes.IJsonValue
                        where T3 : struct, Menes.IJsonValue
                    {
                        var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                        int currentIndex = 0;
                        bool inserted = false;
                        foreach (var oldItem in this._menesArrayValueBacking)
                        {
                            if (currentIndex == index)
                            {
                                arrayBuilder.Add(item1.As<Menes.JsonNumber>());
                                arrayBuilder.Add(item2.As<Menes.JsonNumber>());
                                arrayBuilder.Add(item3.As<Menes.JsonNumber>());
                                inserted = true;
                            }
                            arrayBuilder.Add(oldItem);
                            currentIndex++;
                        }
                        if (!inserted)
                        {
                            throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                        }
                        return new RootEntity.ItemsArray.Items0.ItemsArray(arrayBuilder.ToImmutable());
                    }
                    public ItemsArray Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
                        where T1 : struct, Menes.IJsonValue
                        where T2 : struct, Menes.IJsonValue
                        where T3 : struct, Menes.IJsonValue
                        where T4 : struct, Menes.IJsonValue
                    {
                        var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                        int currentIndex = 0;
                        bool inserted = false;
                        foreach (var oldItem in this._menesArrayValueBacking)
                        {
                            if (currentIndex == index)
                            {
                                arrayBuilder.Add(item1.As<Menes.JsonNumber>());
                                arrayBuilder.Add(item2.As<Menes.JsonNumber>());
                                arrayBuilder.Add(item3.As<Menes.JsonNumber>());
                                arrayBuilder.Add(item4.As<Menes.JsonNumber>());
                                inserted = true;
                            }
                            arrayBuilder.Add(oldItem);
                            currentIndex++;
                        }
                        if (!inserted)
                        {
                            throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                        }
                        return new RootEntity.ItemsArray.Items0.ItemsArray(arrayBuilder.ToImmutable());
                    }
                    public ItemsArray Insert<T>(int index, params T[] items)
                        where T : struct, Menes.IJsonValue
                    {
                        var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                        int currentIndex = 0;
                        bool inserted = false;
                        foreach (var oldItem in this._menesArrayValueBacking)
                        {
                            if (currentIndex == index)
                            {
                                foreach (var item1 in items)
                                {
                                    arrayBuilder.Add(item1.As<Menes.JsonNumber>());
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
                        return new RootEntity.ItemsArray.Items0.ItemsArray(arrayBuilder.ToImmutable());
                    }
                    public ItemsArray RemoveAt(int index)
                    {
                        var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
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
                        return new RootEntity.ItemsArray.Items0.ItemsArray(arrayBuilder.ToImmutable());
                    }
                    public ItemsArray RemoveIf(System.Predicate<Menes.JsonNumber> condition)
                    {
                        return this.RemoveIf<Menes.JsonNumber>(condition);
                    }
                    public ItemsArray RemoveIf<T>(System.Predicate<T> condition)
                        where T : struct, Menes.IJsonValue
                    {
                        var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                        foreach (var item in this._menesArrayValueBacking)
                        {
                            if (!condition(item.As<T>()))
                            {
                                arrayBuilder.Add(item);
                            }
                        }
                        return new RootEntity.ItemsArray.Items0.ItemsArray(arrayBuilder.ToImmutable());
                    }
                    private bool AllBackingFieldsAreNull()
                    {
                        if (this._menesArrayValueBacking is not null)
                        {
                            return false;
                        }
                        return true;
                    }
                    /// <summary>
                    /// An enumerator for the array values in a <see cref="ItemsArray"/>.
                    /// </summary>
                    public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonNumber>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonNumber>, System.Collections.IEnumerator
                    {
                        private ItemsArray instance;
                        private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                        private bool hasJsonEnumerator;
                        private int index;
                        internal MenesArrayEnumerator(ItemsArray instance)
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
                        public Menes.JsonNumber Current
                        {
                            get
                            {
                                if (this.hasJsonEnumerator)
                                {
                                    return new Menes.JsonNumber(this.jsonEnumerator.Current);
                                }
                                else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonNumber> array && this.index >= 0 && this.index < array.Length)
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
                        /// <returns>An enumerator for the array values in a <see cref="ItemsArray"/>.</returns>
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
                        System.Collections.Generic.IEnumerator<Menes.JsonNumber> System.Collections.Generic.IEnumerable<Menes.JsonNumber>.GetEnumerator()
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
                            else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonNumber> array && this.index + 1 < array.Length)
                            {
                                this.index++;
                                return true;
                            }
                            return false;
                        }
                    }
                }
                /// <summary>
                /// An enumerator for the array values in a <see cref="Items0"/>.
                /// </summary>
                public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<RootEntity.ItemsArray.Items0.ItemsArray>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<RootEntity.ItemsArray.Items0.ItemsArray>, System.Collections.IEnumerator
                {
                    private Items0 instance;
                    private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                    private bool hasJsonEnumerator;
                    private int index;
                    internal MenesArrayEnumerator(Items0 instance)
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
                    public RootEntity.ItemsArray.Items0.ItemsArray Current
                    {
                        get
                        {
                            if (this.hasJsonEnumerator)
                            {
                                return new RootEntity.ItemsArray.Items0.ItemsArray(this.jsonEnumerator.Current);
                            }
                            else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray.Items0.ItemsArray> array && this.index >= 0 && this.index < array.Length)
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
                    /// <returns>An enumerator for the array values in a <see cref="Items0"/>.</returns>
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
                    System.Collections.Generic.IEnumerator<RootEntity.ItemsArray.Items0.ItemsArray> System.Collections.Generic.IEnumerable<RootEntity.ItemsArray.Items0.ItemsArray>.GetEnumerator()
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
                        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray.Items0.ItemsArray> array && this.index + 1 < array.Length)
                        {
                            this.index++;
                            return true;
                        }
                        return false;
                    }
                }
            }
            /// <summary>
            /// An enumerator for the array values in a <see cref="ItemsArray"/>.
            /// </summary>
            public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<RootEntity.ItemsArray.Items0>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<RootEntity.ItemsArray.Items0>, System.Collections.IEnumerator
            {
                private ItemsArray instance;
                private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                internal MenesArrayEnumerator(ItemsArray instance)
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
                public RootEntity.ItemsArray.Items0 Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new RootEntity.ItemsArray.Items0(this.jsonEnumerator.Current);
                        }
                        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray.Items0> array && this.index >= 0 && this.index < array.Length)
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
                /// <returns>An enumerator for the array values in a <see cref="ItemsArray"/>.</returns>
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
                System.Collections.Generic.IEnumerator<RootEntity.ItemsArray.Items0> System.Collections.Generic.IEnumerable<RootEntity.ItemsArray.Items0>.GetEnumerator()
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
                    else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray.Items0> array && this.index + 1 < array.Length)
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
        public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<RootEntity.ItemsArray>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<RootEntity.ItemsArray>, System.Collections.IEnumerator
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
            public RootEntity.ItemsArray Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new RootEntity.ItemsArray(this.jsonEnumerator.Current);
                    }
                    else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray> array && this.index >= 0 && this.index < array.Length)
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
            System.Collections.Generic.IEnumerator<RootEntity.ItemsArray> System.Collections.Generic.IEnumerable<RootEntity.ItemsArray>.GetEnumerator()
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
                else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<RootEntity.ItemsArray> array && this.index + 1 < array.Length)
                {
                    this.index++;
                    return true;
                }
                return false;
            }
        }
    }
}
